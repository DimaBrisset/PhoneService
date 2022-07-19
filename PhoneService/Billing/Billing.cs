namespace PhoneService
{
    public class Billing : IBilling
    {
        private readonly IStorage<CallInformation> _storage;
        public Billing(IStorage<CallInformation> storage)
        {
            _storage = storage;
        }

        public Report GetReport(int telephoneNumber)
        {
            var calls = _storage.GetInformationAboutList().
                Where(x => x.MyNumber == telephoneNumber || x.TargetNumber == telephoneNumber).
                ToList();
            var report = new Report();

            foreach (var call in calls)
            {
                CallType callType;
                int number;
                if (call.MyNumber == telephoneNumber)
                {
                    callType = CallType.OutCall;
                    number = call.TargetNumber;
                }
                else
                {
                    callType = CallType.InCall;
                    number = call.MyNumber;
                }
                var record = new ReportRecord(callType, number, call.BeginCall, new DateTime((call.EndCall - call.BeginCall).Ticks), call.Cost);
                report.AddRecord(record);
            }
            return report;
        }

    }
}
