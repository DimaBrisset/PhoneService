namespace PhoneService
{
    public interface IBillingSystem
    {
        Report GetReport(int telephoneNumber);
    }
}
