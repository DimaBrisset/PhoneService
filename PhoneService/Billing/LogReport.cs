using PhoneService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Billing
{
    internal class LogReport
    {
        public TypeCall TypeCall { get; set; }
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Time { get; private set; }
        public int Amount { get; private set; }
        public LogReport(TypeCall typeCall, int number, DateTime date, DateTime time, int amount)
        {
            TypeCall = typeCall;
            Number = number;
            Date = date;
            Time = time;
            Amount = amount;
        }
    }
}
