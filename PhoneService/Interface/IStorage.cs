namespace PhoneService
{
    public interface IStorage<T>
    {
        IList<T> GetInfoList();
    }
}
