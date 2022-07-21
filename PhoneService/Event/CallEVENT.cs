namespace PhoneService
{
    public class CallEVENT : EventArgs, ICallingEVENT
    {
        public int PhoneNumber { get; private set; }
        public int TargetPhoneNumber { get; private set; }
        public Guid Id { get; private set; }
        public CallEVENT(int number, int target)
        {
            PhoneNumber = number;
            TargetPhoneNumber = target;
        }
        public CallEVENT(int number, int target, Guid id)
        {
            PhoneNumber = number;
            TargetPhoneNumber = target;
            Id = id;
        }
    }
}
