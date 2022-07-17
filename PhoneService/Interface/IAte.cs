namespace PhoneService
{
    public interface IATE : IStorage<CallInformation>
    {
        Terminal GetNewTerminal(IContract contract);
        IContract RegisterContract(Subscriber subscriber, TariffType type);
        void CallingTo(object sender, ICallingEventArgs e);
    }
}
