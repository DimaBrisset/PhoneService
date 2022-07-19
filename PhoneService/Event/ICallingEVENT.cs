namespace PhoneService
{
    public interface ICallingEVENT
    {
        int TelephoneNumber { get; }
        int TargetTelephoneNumber { get; }
        Guid Id { get; }
    }
}
