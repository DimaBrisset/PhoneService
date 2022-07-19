namespace PhoneService
{
    public class CallEVENT : EventArgs, ICallingEVENT
    {
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }
        public Guid Id { get; private set; }
        public CallEVENT(int number, int target)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
        }
        public CallEVENT(int number, int target, Guid id)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            Id = id;
        }
    }
}
