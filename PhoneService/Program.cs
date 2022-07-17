using PhoneService.Billing;
using PhoneService.Enum;
using PhoneService.Interface;



namespace PhoneService.ATE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IAte ate = new Ate();
            ILog render = new SortedLogs();
            IBilling bs = new Billing.Billing(ate);


            IContract c1 = ate.RegisterContract(new User("Vasia"), Enum.TypeTariff.StartTariff);
            IContract c2 = ate.RegisterContract(new User("Dima"), Enum.TypeTariff.StandardTariff);
            IContract c3 = ate.RegisterContract(new User("Petya"), Enum.TypeTariff.UltraTariff);

            c1.User.BalanceAdd(50);
            var t1 = ate.GetTerminal(c1);
            var t2 = ate.GetTerminal(c2);
            var t3 = ate.GetTerminal(c3);
            t1.ConnectedPort();
            t2.ConnectedPort();
            t3.ConnectedPort();
            t1.Call(t2.Number);
            Thread.Sleep(2000);
            t2.EndCall();
            t3.Call(t1.Number);
            Thread.Sleep(1000);
            t3.EndCall();
            t2.Call(t1.Number);
            Thread.Sleep(3000);
            t1.EndCall();

            Console.WriteLine();
            Console.WriteLine("Sorted records:");
            foreach (var item in render.SortCalls(bs.GetReport(t1.Number), Sorted.SortCall))
            {
                Console.WriteLine("Calls:\n Type {0} |\n Date: {1} |\n Duration: {2} | Cost: {3} | Telephone number: {4}",
                    item.TypeCall, item.Date, item.Time.ToString("mm:ss"), item.Amount, item.Number);
            }

            Console.ReadKey();

        }
    }
}