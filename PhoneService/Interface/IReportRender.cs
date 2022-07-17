namespace PhoneService
{
    public interface IReportRender
    {
        void Render(Report report);
        IEnumerable<ReportRecord> SortCalls(Report report, TypeSort sortType);
    }
}
