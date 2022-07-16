using PhoneService.Enum;
using PhoneService.Interface;


namespace PhoneService.Billing
{
    internal class Contract : IContract
    {


        public User User { get; private set; }
        public int Number { get; private set; }
        public Tariffs Tariffs { get; private set; }
        private DateTime LastTariffUpdateDate;
        static Random random = new();




        public Contract(User user, TypeTariff tariffType)
        {
            User = user;
            LastTariffUpdateDate = DateTime.Now;
            Tariffs = new Tariffs(tariffType);
            Number = random.Next(1000000, 9999999);

        }

        public bool ChangeTariff(TypeTariff typeTariff)
        {
            if (DateTime.Now.AddMonths(-1) >= LastTariffUpdateDate)
            {
                LastTariffUpdateDate = DateTime.Now;
                Tariffs = new Tariffs(typeTariff);
                Console.WriteLine("Тариф Поменялся");
                return true;
            }
            else
            {
                Console.WriteLine("Жди до конца месяца");
                return false;
            }
        }
    }
}
