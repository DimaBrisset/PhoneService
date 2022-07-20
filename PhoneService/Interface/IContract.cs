namespace PhoneService
{
    public interface IContract
    {
        User User { get; }
        int Number { get; }
        Tariff Tariff { get; }
        bool ChangeTariff(TariffType tariffType);
    }
}
