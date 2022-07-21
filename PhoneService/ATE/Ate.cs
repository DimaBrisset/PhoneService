
namespace PhoneService
{
    public class ATE : IATE
    {
        private readonly IDictionary<int, Tuple<Port, IContract>> _usersData;
        private readonly IList<CallInformation> _callList = new List<CallInformation>();
        public ATE()
        {
            _usersData = new Dictionary<int, Tuple<Port, IContract>>();

        }

        public Terminal GetNewTerminal(IContract contract)
        {
            var newPort = new Port();
            newPort.AnswerEvent += CallingTo;
            newPort.CallEvent += CallingTo;
            newPort.EndCallEvent += CallingTo;
            _usersData.Add(contract.Number, new Tuple<Port, IContract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);
            return newTerminal;
        }

        public IContract RegisterContract(User subscriber, TariffType type)
        {
            var contract = new Contract(subscriber, type);
            return contract;
        }




        public void CallingTo(object? sender, ICallingEVENT e)
        {
            if ((_usersData.ContainsKey(e.TargetPhoneNumber) && e.TargetPhoneNumber != e.PhoneNumber)
                || e is EndEVENT)
            {
                CallInformation? inf = null;
                Port targetPort;
                Port port;
                int number = 0;
                int targetNumber = 0;

                if (e is EndEVENT)
                {
                    var callListFirst = _callList.First(x => x.Id.Equals(e.Id));
                    if (callListFirst.MyNumber == e.PhoneNumber)
                    {
                        targetPort = _usersData[callListFirst.TargetNumber].Item1;
                        port = _usersData[callListFirst.MyNumber].Item1;
                        number = callListFirst.MyNumber;
                        targetNumber = callListFirst.TargetNumber;
                    }
                    else
                    {
                        port = _usersData[callListFirst.TargetNumber].Item1;
                        targetPort = _usersData[callListFirst.MyNumber].Item1;
                        targetNumber = callListFirst.MyNumber;
                        number = callListFirst.TargetNumber;
                    }
                }
                else
                {
                    targetPort = _usersData[e.TargetPhoneNumber].Item1;
                    port = _usersData[e.PhoneNumber].Item1;
                    targetNumber = e.TargetPhoneNumber;
                    number = e.PhoneNumber;
                }
                if (targetPort.State == PortState.Connect && port.State == PortState.Connect)
                {
                    var tuple = _usersData[number];
                    var targetTuple = _usersData[targetNumber];

                    if (e is EventAnswer answerArgs)
                    {
                        if (!answerArgs.Id.Equals(Guid.Empty) && _callList.Any(x => x.Id.Equals(answerArgs.Id)))
                        {
                            inf = _callList.First(x => x.Id.Equals(answerArgs.Id));
                        }

                        if (inf != null)
                        {
                            targetPort.AnswerCall(answerArgs.PhoneNumber, answerArgs.TargetPhoneNumber, answerArgs.StateInCall, inf.Id);
                        }
                        else
                        {
                            targetPort.AnswerCall(answerArgs.PhoneNumber, answerArgs.TargetPhoneNumber, answerArgs.StateInCall);
                        }
                    }






                    if (e is CallEVENT args)
                    {
                        if (tuple.Item2.User.Money > tuple.Item2.Tariff.CostOfCallPerMinute)
                        {
                            var callArgs = args;

                            if (callArgs.Id.Equals(Guid.Empty))
                            {
                                inf = new CallInformation(
                                    callArgs.PhoneNumber,
                                    callArgs.TargetPhoneNumber,
                                    DateTime.Now);
                                _callList.Add(inf);
                            }

                            if (!callArgs.Id.Equals(Guid.Empty) && _callList.Any(x => x.Id.Equals(callArgs.Id)))
                            {
                                inf = _callList.First(x => x.Id.Equals(callArgs.Id));
                            }
                            if (inf != null)
                            {
                                targetPort.IncomingCall(callArgs.PhoneNumber, callArgs.TargetPhoneNumber, inf.Id);
                            }
                            else
                            {
                                targetPort.IncomingCall(callArgs.PhoneNumber, callArgs.TargetPhoneNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Terminal with number {0} is not enough money in the account!", e.PhoneNumber);

                        }
                    }






                    if (e is EndEVENT args1)
                    {
                        inf = _callList.First(x => x.Id.Equals(args1.Id));
                        inf.EndCall = DateTime.Now;
                        var sumOfCall = tuple.Item2.Tariff.CostOfCallPerMinute * TimeSpan.FromTicks((inf.EndCall - inf.BeginCall).Ticks).TotalMinutes;
                        inf.Cost = (int)sumOfCall;
                        targetTuple.Item2.User.RemoveMoney(inf.Cost);
                        targetPort.AnswerCall(args1.PhoneNumber, args1.TargetPhoneNumber, CallState.NotPickUpPhone, inf.Id);
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


        public IList<CallInformation> GetInformationAboutList()
        {
            return _callList;
        }
    }
}
