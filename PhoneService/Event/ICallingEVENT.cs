namespace PhoneService
{
    public interface ICallingEVENT
    {
        int PhoneNumber { get; }
        int TargetTelephoneNumber { get; }
        Guid Id { get; }
    }
}
