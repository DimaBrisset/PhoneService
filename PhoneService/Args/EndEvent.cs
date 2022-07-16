using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Args
{
    internal class EndEvent : EventArgs
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }


        public EndEvent(Guid id, int phoneNumber)
        {
            Id = id;
            PhoneNumber = phoneNumber;
        }


    }
}
