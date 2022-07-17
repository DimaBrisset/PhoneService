using PhoneService.Enum;
using PhoneService.Interface;

namespace PhoneService.Billing
{
    internal class SortedLogs : ILog
    {
        public void SaveLogs(Log log)
        {
            foreach (var logs in log.GetLog())
            {
                Console.WriteLine($"Calls:\n Type {logs.TypeCall} |\n Date: {logs.Date} |\n Duration: {logs.Time.ToString("mm.ss")} | Cost: {logs.Amount} | Telephone number: {logs.Number}");


            }

        }

        public IEnumerable<LogReport> SortCalls(Log log, Sorted sorted)
        {
            var rep = log.GetLog();
            switch (sorted)
            {
                case Sorted.SortCall:
                    return rep = rep.
                        OrderBy(x => x.TypeCall).
                        ToList();

                case Sorted.SortDate:
                    return rep = rep.
                        OrderBy(x => x.Date).
                        ToList();

                case Sorted.SortAmount:
                    return rep = rep
                        .OrderBy(x => x.Amount)
                        .ToList();

                case Sorted.SortNumber:
                    return rep = rep.
                        OrderBy(x => x.Number).
                        ToList();

                default:
                    return rep;
            }
        }
    }
}
