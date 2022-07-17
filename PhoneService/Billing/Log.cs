using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Billing
{
   internal class Log
    {
        private readonly IList<LogReport> _listLogReport;

        public Log()
        {
            _listLogReport = new List<LogReport>();
        }

        public void AddLog(LogReport log)
        {
            _listLogReport.Add(log);
        }

        public IList<LogReport> GetLog()
        {
            return _listLogReport;
        }


    }
}
