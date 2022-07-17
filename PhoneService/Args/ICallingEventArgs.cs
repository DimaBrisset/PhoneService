namespace PhoneService
{
    public interface ICallingEventArgs
    {
        int TelephoneNumber { get; }
        int TargetTelephoneNumber { get; }
        Guid Id { get; }
    }
}
