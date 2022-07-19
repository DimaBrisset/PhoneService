namespace PhoneService
{
    public class EndEVENT : EventArgs, ICallingEVENT
    {
        public Guid Id { get; private set; }
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }

        public EndEVENT(Guid id, int number)
        {
            Id = id;
            TelephoneNumber = number;
        }
    }
}
