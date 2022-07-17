using PhoneService.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Interface
{
    internal interface IBilling
    {
       Log GetReport(int telephoneNumber);
    }
}
