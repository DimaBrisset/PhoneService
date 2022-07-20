namespace PhoneService
{
    public class CallEVENT : EventArgs, ICallingEVENT
    {
        public int PhoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }
        public Guid Id { get; private set; }
        public CallEVENT(int number, int target)
        {
            PhoneNumber = number;
            TargetTelephoneNumber = target;
        }
        public CallEVENT(int number, int target, Guid id)
        {
            PhoneNumber = number;
            TargetTelephoneNumber = target;
            Id = id;
        }
    }
}
