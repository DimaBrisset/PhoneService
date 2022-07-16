using PhoneService.Args;
using PhoneService.Billing;
using PhoneService.Enum;
using PhoneService.Interface;






namespace PhoneService.ATE
{
    public class Ate : IAte
    {
        private IList<ContractInformation> _listInformation = new List<ContractInformation>();
        private IDictionary<int, Tuple<Port, IContract>> _usersData;

        public Ate()
        {
            _usersData = new Dictionary<int, Tuple<Port, IContract>>();

        }


        public void CallingTo(object sender, ICallARGS e)
        {
            if ((_usersData.ContainsKey(e.TargetPhoneNumber) && e.TargetPhoneNumber != e.PhoneNumber)
                || e is EndEventARGS)
            {
                ContractInformation inf = null;
                Port targetPort;
                Port port;
                int number = 0;
                int targetNumber = 0;
                if (e is EndEventARGS)
                {
                    var callListFirst = _listInformation.First(x => x.Id.Equals(e.Id));
                    if (callListFirst.PhoneNumber == e.PhoneNumber)
                    {
                        targetPort = _usersData[callListFirst.TargetPhoneNumber].Item1;
                        port = _usersData[callListFirst.PhoneNumber].Item1;
                        number = callListFirst.PhoneNumber;
                        targetNumber = callListFirst.TargetPhoneNumber;
                    }
                    else
                    {
                        port = _usersData[callListFirst.TargetPhoneNumber].Item1;
                        targetPort = _usersData[callListFirst.PhoneNumber].Item1;
                        targetNumber = callListFirst.PhoneNumber;
                        number = callListFirst.TargetPhoneNumber;
                    }
                }
                else
                {
                    targetPort = _usersData[e.TargetPhoneNumber].Item1;
                    port = _usersData[e.PhoneNumber].Item1;
                    targetNumber = e.TargetPhoneNumber;
                    number = e.PhoneNumber;
                }
                if (targetPort.PortStatus == StatusPort.Connect && port.PortStatus == StatusPort.Connect)
                {
                    var tuple = _usersData[number];
                    var targetTuple = _usersData[targetNumber];

                    if (e is AnswerEventARGS answerArgs)
                    {
                        if (!answerArgs.Id.Equals(Guid.Empty) && _listInformation.Any(x => x.Id.Equals(answerArgs.Id)))
                        {
                            inf = _listInformation.First(x => x.Id.Equals(answerArgs.Id));
                        }

                        if (inf != null)
                        {
                            targetPort.AnswerCall(answerArgs.PhoneNumber, answerArgs.TargetPhoneNumber, answerArgs.CallStatus, inf.Id);
                        }
                        else
                        {
                            targetPort.AnswerCall(answerArgs.PhoneNumber, answerArgs.TargetPhoneNumber, answerArgs.CallStatus);
                        }
                    }
                    if (e is CallEventARGS aRGS)
                    {
                        if (tuple.Item2.User.Balance > tuple.Item2.Tariffs.AmountMinute)
                        {
                            var callArgs = aRGS;

                            if (callArgs.Id.Equals(Guid.Empty))
                            {
                                inf = new ContractInformation(
                                    callArgs.PhoneNumber,
                                    callArgs.TargetPhoneNumber,
                                    DateTime.Now);
                                _listInformation.Add(inf);
                            }

                            if (!callArgs.Id.Equals(Guid.Empty) && _listInformation.Any(x => x.Id.Equals(callArgs.Id)))
                            {
                                inf = _listInformation.First(x => x.Id.Equals(callArgs.Id));
                            }
                            if (inf != null)
                            {
                                targetPort.InCall(callArgs.PhoneNumber, callArgs.TargetPhoneNumber, inf.Id);
                            }
                            else
                            {
                                targetPort.InCall(callArgs.PhoneNumber, callArgs.TargetPhoneNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Terminal with number {0} is not enough money in the account!", e.TargetPhoneNumber);

                        }
                    }
                    if (e is EndEventARGS args)
                    {
                        inf = _listInformation.First(x => x.Id.Equals(args.Id));
                        inf.EndCall = DateTime.Now;
                        var sumOfCall = tuple.Item2.Tariffs.AmountMinute * TimeSpan.FromTicks((inf.EndCall - inf.StartCall).Ticks).TotalMinutes;
                        inf.Amount = (int)sumOfCall;
                        targetTuple.Item2.User.BalanceWithdraw(inf.Amount);
                        targetPort.AnswerCall(args.PhoneNumber, args.TargetPhoneNumber, StatusCall.Reject, inf.Id);
                    }
                }
            }
            else if (!_usersData.ContainsKey(e.TargetPhoneNumber))
            {
                Console.WriteLine("You have calling a non-existent number!!!");
            }
            else
            {
                Console.WriteLine("You have calling a your number!!!");
            }
        }









        public Terminal GetTerminal(IContract contract)
        {
            Port port = new();
            port.AnswerEvent += CallingTo;
            port.CallEvent += CallingTo;
            port.EndEvent += CallingTo;
            _usersData.Add(contract.Number, new Tuple<Port, IContract>(port, contract));
            var newTerminal = new Terminal(contract.Number, port);
            return newTerminal;

        }

      

        public IList<ContractInformation> ListInformation()
        {
            return _listInformation;
        }

    


        public IContract RegisterContract(User user, TypeTariff type)
        {
            var contract = new Contract(user, type);
            return contract;
        }




    }
}
