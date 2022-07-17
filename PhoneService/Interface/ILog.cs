using PhoneService.Billing;
using PhoneService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Interface
{
    internal interface ILog
    {
        void SaveLogs(Log log) ;
        IEnumerable<LogReport> SortCalls(Log log,Sorted sorted);

    }
}
