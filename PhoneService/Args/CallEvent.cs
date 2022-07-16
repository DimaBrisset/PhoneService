using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Args
{
    internal class CallEvent : EventArgs
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }


        public CallEvent(int phoneNumber, int targetPhoneNumeber)
        {
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumeber;
        }
        public CallEvent(int phoneNmber, int targetPhoneNumeber, Guid id)
        {
            PhoneNumber = phoneNmber;
            TargetPhoneNumber = targetPhoneNumeber;
            Id = id;
        }

    }
}
