namespace PhoneService
{
    public class Tariff
    {
        public int CostOfMonth { get; private set; }
        public int CostOfCallPerMinute { get; private set; }
        public int LimitCallInMonth { get; private set; }
        public TariffType TariffType { get; private set; }
        public Tariff(TariffType type)
        {
            TariffType = type;
            switch (TariffType)
            {
                case TariffType.Start:
                    {
                        CostOfMonth = 100;
                        LimitCallInMonth = 10;
                        CostOfCallPerMinute = 1;
                        break;
                    }
                case TariffType.Standard:
                    {
                        CostOfMonth = 200;
                        LimitCallInMonth = 20;
                        CostOfCallPerMinute = 2;
                        break;
                    }
                case TariffType.Ultra:
                    {
                        CostOfMonth = 300;
                        LimitCallInMonth = 30;
                        CostOfCallPerMinute = 3;
                        break;
                    }
                default:
                    {
                        CostOfMonth = 0;
                        LimitCallInMonth = 0;
                        CostOfCallPerMinute = 0;
                        break;
                    }
            }
        }
    }
}
