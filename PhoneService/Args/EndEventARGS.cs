using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Args
{
    public class EndEventARGS : EventArgs,ICallARGS
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }
  

        public EndEventARGS(Guid id, int phoneNumber)
        {
            Id = id;
            PhoneNumber = phoneNumber;
        }


    }
}
