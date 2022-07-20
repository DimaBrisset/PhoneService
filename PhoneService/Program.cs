namespace PhoneService
{
    class Program
    {
        static void Main(string[] args)
        {
            IATE ate = new ATE();


            IReportRender render = new ReportRender();
            IBilling bs = new Billing(ate);

            IContract c1 = ate.RegisterContract(new User("Vasia"), TariffType.Standard);
            IContract c2 = ate.RegisterContract(new User("Dima"), TariffType.Standard);
            IContract c3 = ate.RegisterContract(new User("Petya"), TariffType.Ultra);

            c1.User.AddMoney(10);
            var t1 = ate.GetNewTerminal(c1);
            var t2 = ate.GetNewTerminal(c2);
            var t3 = ate.GetNewTerminal(c3);
            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();
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
            foreach (var item in render.SortCalls(bs.GetReport(t1.Number), TypeSort.SortByCallType))
            {
                Console.WriteLine("Calls:\n Type {0} |\n Date: {1} |\n Duration: {2} | Cost: {3} | Telephone number: {4}",
                    item.CallType, item.Date, item.Time.ToString("mm:ss"), item.Cost, item.Number);
            }
            
            Console.ReadKey();


        }
    }
}
