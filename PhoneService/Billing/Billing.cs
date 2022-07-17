using PhoneService.ATE;
using PhoneService.Enum;
using PhoneService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Billing
{
    internal class Billing:IBilling
    {
        private IStor<ContractInformation> _storage;
        public Billing(IStor<ContractInformation> storage)
        {
            _storage = storage;
        }


        public Log GetReport(int phoneNumber)
        {
            var calls = _storage.ListInformation().
                Where(x => x.PhoneNumber == phoneNumber || x.TargetPhoneNumber == phoneNumber).
                ToList();
            var log = new Log();

            foreach (var call in calls)
            {
                TypeCall callType;
                int number;
                if (call.PhoneNumber == phoneNumber)
                {
                    callType = TypeCall.CallOutgoing;
                    number = call.TargetPhoneNumber;
                }
                else
                {
                    callType = TypeCall.CallIncoming;
                    number = call.PhoneNumber;
                }
                var record = new LogReport(callType, number, call.StartCall, new DateTime((call.EndCall - call.StartCall).Ticks), call.Amount); // TimeSpan.FromTicks((call.EndCall - call.BeginCall).Ticks) .TotalMinutes  
                log.AddLog(record);
            }
            return log;
        }



    }
}
