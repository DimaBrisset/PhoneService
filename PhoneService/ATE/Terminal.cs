namespace PhoneService
{
    public class Terminal
    {
        private readonly int _number;
        public int Number
        {
            get
            {
                return _number;
            }
        }
        private readonly Port _terminalPort;
        private Guid _id;

        public event EventHandler<CallEVENT>? CallEvent;
        public event EventHandler<EventAnswer>? AnswerEvent;
        public event EventHandler<EndEVENT>? EndCallEvent;
        public Terminal(int number, Port port)
        {
            this._number = number;
            this._terminalPort = port;
        }
        protected virtual void RaiseCallEvent(int targetNumber)
        {
            CallEvent?.Invoke(this, new CallEVENT(_number, targetNumber));
        }

        protected virtual void RaiseAnswerEvent(int targetNumber, CallState state, Guid id)
        {
            AnswerEvent?.Invoke(this, new EventAnswer(_number, targetNumber, state, id));
        }

        protected virtual void RaiseEndCallEvent(Guid id)
        {
            EndCallEvent?.Invoke(this, new EndEVENT(id, _number));
        }

        public void Call(int targetNumber)
        {
            RaiseCallEvent(targetNumber);
        }

        public void TakeIncomingCall(object? sender, CallEVENT e)
        {
            bool flag = true;
            _id = e.Id;
            Console.WriteLine($"Have incoming Call at number: {e.PhoneNumber} to terminal {e.TargetPhoneNumber}");
            while (flag == true)
            {
                Console.WriteLine("Answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(e.PhoneNumber, CallState.PickUpPhone, e.Id);
                }
                else if (k == 'N' || k == 'n')
                {
                    flag = false;
                    Console.WriteLine();
                    EndCall();
                }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
            }
        }

        public void ConnectToPort()
        {
            if (_terminalPort.Connect(this))
            {
                _terminalPort.CallPortEvent += TakeIncomingCall;
                _terminalPort.AnswerPortEvent += TakeAnswer;
            }
        }

        public void AnswerToCall(int target, CallState state, Guid id)
        {
            RaiseAnswerEvent(target, state, id);
        }

        public void EndCall()
        {
            RaiseEndCallEvent(_id);
        }

        public void TakeAnswer(object? sender, EventAnswer e)
        {
            _id = e.Id;
            if (e.StateInCall == CallState.PickUpPhone)
            {
                Console.WriteLine($"Terminal with number: {e.PhoneNumber}, have answer on call a number: {e.TargetPhoneNumber}");
            }
            else
            {
                Console.WriteLine($"Terminal with number: {e.PhoneNumber}, have rejected call");
            }
            
        }
    }
}