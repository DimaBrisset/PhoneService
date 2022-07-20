namespace PhoneService
{
    public interface IATE : IStorage<CallInformation>
    {
        Terminal GetNewTerminal(IContract contract);
        IContract RegisterContract(User user, TariffType type);
        void CallingTo(object sender, ICallingEVENT e);
    }
}
