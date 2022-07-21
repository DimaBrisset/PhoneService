namespace PhoneService
{
    public class EventAnswer : EventArgs, ICallingEVENT
    {
        public int PhoneNumber { get; private set; }
        public int TargetPhoneNumber { get; private set; }
        public CallState StateInCall;
        public Guid Id { get; private set; }
        public EventAnswer(int number, int target, CallState state)
        {
            PhoneNumber = number;
            TargetPhoneNumber = target;
            StateInCall = state;
        }
        public EventAnswer(int number, int target, CallState state, Guid id)
        {
            PhoneNumber = number;
            TargetPhoneNumber = target;
            StateInCall = state;
            Id = id;
        }


    }
}
