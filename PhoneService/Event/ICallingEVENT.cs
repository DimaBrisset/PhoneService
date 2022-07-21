namespace PhoneService
{
    public interface ICallingEVENT
    {
        int PhoneNumber { get; }
        int TargetPhoneNumber { get; }
        Guid Id { get; }
    }
}
