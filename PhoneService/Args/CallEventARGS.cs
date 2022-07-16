using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Args
{
    public class CallEventARGS : EventArgs,ICallARGS
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }


        public CallEventARGS(int phoneNumber, int targetPhoneNumeber)
        {
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumeber;
        }
        public CallEventARGS(int phoneNumber, int targetPhoneNumeber, Guid id)
        {
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumeber;
            Id = id;
        }

    }
}
