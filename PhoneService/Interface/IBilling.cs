namespace PhoneService
{
    public interface IBilling
    {
        Report GetReport(int telephoneNumber);
    }
}
