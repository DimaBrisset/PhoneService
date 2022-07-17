namespace PhoneService
{
    public interface IContract
    {
        Subscriber Subscriber { get; }
        int Number { get; }
        Tariff Tariff { get; }
        bool ChangeTariff(TariffType tariffType);
    }
}
