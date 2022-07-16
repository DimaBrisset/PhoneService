using PhoneService.Enum;

namespace PhoneService.Billing
{
   public class Tariffs
    {
        public int AmountMonth { get;  set; }
        public int AmountMinute { get; set; }
        public int LimitedOfMonth { get;  set; }
        public TypeTariff TypeTariff { get; set; }


        public Tariffs(TypeTariff type)
        {
            TypeTariff = type;
            switch (TypeTariff)
            {
                case TypeTariff.StartTariff:
                    {
                        AmountMonth = 100;
                        AmountMinute = 10;
                        LimitedOfMonth = 5;
                        break;
                    }
                case TypeTariff.StandardTariff:
                    {
                        AmountMonth = 200;
                        AmountMinute = 20;
                        LimitedOfMonth = 5;
                        break;
                    }
                case TypeTariff.UltraTariff:
                    {
                        AmountMonth = 300;
                        AmountMinute = 30;
                        LimitedOfMonth = 5;
                        break;
                    }
                default:
                    {
                        AmountMonth = 0;
                        AmountMinute = 0;
                        LimitedOfMonth = 0;
                        break;
                    }
            }
        }
    }
}
