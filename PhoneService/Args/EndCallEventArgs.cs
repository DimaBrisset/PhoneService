namespace PhoneService
{
    public class EndCallEventArgs : EventArgs, ICallingEventArgs
    {
        public Guid Id { get; private set; }
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }

        public EndCallEventArgs(Guid id, int number)
        {
            Id = id;
            TelephoneNumber = number;
        }
    }
}
