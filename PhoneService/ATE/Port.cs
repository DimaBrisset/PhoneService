namespace PhoneService
{

    public class Port
    {
        public PortState State;
        public bool Flag;

        public event EventHandler<CallEVENT>? CallPortEvent;
        public event EventHandler<EventAnswer>? AnswerPortEvent;
        public event EventHandler<CallEVENT>? CallEvent;
        public event EventHandler<EventAnswer>? AnswerEvent;

        public event EventHandler<EndEVENT>? EndCallEvent;

        public Port()
        {
            State = PortState.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                terminal.CallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndCallEvent += EndCall;
                Flag = true;
            }
            return Flag;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                terminal.CallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndCallEvent -= EndCall;
                Flag = false;
            }
            return false;
        }

        protected virtual void RaiseIncomingCallEvent(int number, int targetNumber)
        {
            CallPortEvent?.Invoke(this, new CallEVENT(number, targetNumber));
        }
        protected virtual void RaiseIncomingCallEvent(int number, int targetNumber, Guid id)
        {
            CallPortEvent?.Invoke(this, new CallEVENT(number, targetNumber, id));
        }
        protected virtual void RaiseAnswerCallEvent(int number, int targetNumber, CallState state)
        {
            AnswerPortEvent?.Invoke(this, new EventAnswer(number, targetNumber, state));
        }
        protected virtual void RaiseAnswerCallEvent(int number, int targetNumber, CallState state, Guid id)
        {
            AnswerPortEvent?.Invoke(this, new EventAnswer(number, targetNumber, state, id));
        }

        protected virtual void RaiseCallingToEvent(int number, int targetNumber)
        {
            CallEvent?.Invoke(this, new CallEVENT(number, targetNumber));
        }

        protected virtual void RaiseAnswerToEvent(EventAnswer eventArgs)
        {
            AnswerEvent?.Invoke(this, new EventAnswer(
    eventArgs.PhoneNumber,
    eventArgs.TargetPhoneNumber,
    eventArgs.StateInCall,
    eventArgs.Id));
        }

        protected virtual void RaiseEndCallEvent(Guid id, int number)
        {
            EndCallEvent?.Invoke(this, new EndEVENT(id, number));
        }

        private void CallingTo(object? sender, CallEVENT e)
        {
            RaiseCallingToEvent(e.PhoneNumber, e.TargetPhoneNumber);
        }

        private void AnswerTo(object? sender, EventAnswer e)
        {
            RaiseAnswerToEvent(e);
        }

        private void EndCall(object? sender, EndEVENT e)
        {
            RaiseEndCallEvent(e.Id, e.PhoneNumber);
        }

        public void IncomingCall(int number, int targetNumber)
        {
            RaiseIncomingCallEvent(number, targetNumber);
        }
        public void IncomingCall(int number, int targetNumber, Guid id)
        {
            RaiseIncomingCallEvent(number, targetNumber, id);
        }

        public void AnswerCall(int number, int targetNumber, CallState state)
        {
            RaiseAnswerCallEvent(number, targetNumber, state);
        }
        public void AnswerCall(int number, int targetNumber, CallState state, Guid id)
        {
            RaiseAnswerCallEvent(number, targetNumber, state, id);
        }


    }
}
