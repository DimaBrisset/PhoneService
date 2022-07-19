namespace PhoneService
{
    public class ReportRender : IReportRender
    {
        public ReportRender()
        {

        }
        public void Render(Report report)
        {
    
            foreach (var record in report.GetRecords())
            {
                Console.WriteLine($"Calls:\n Type {record.CallType} |\n Date: {record.Date} |\n Duration: {record.Time.ToString("mm:ss")} | Cost: {record.Cost} | Telephone number: {record.Number}");
                




            }
        }
        public IEnumerable<ReportRecord> SortCalls(Report report, TypeSort sortType)
        {
            var rep = report.GetRecords();
            switch (sortType)
            {
                case TypeSort.SortByCallType:
                    return rep = rep.
                        OrderBy(x => x.CallType).
                        ToList();

                case TypeSort.SortByDate:
                    return rep = rep.
                        OrderBy(x => x.Date).
                        ToList();

                case TypeSort.SortByCost:
                    return rep = rep
                        .OrderBy(x => x.Cost)
                        .ToList();

                case TypeSort.SortByNumber:
                    return rep = rep.
                        OrderBy(x => x.Number).
                        ToList();

                default:
                    return rep;
            }
        }
    }
}
