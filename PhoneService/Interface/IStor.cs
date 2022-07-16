using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Interface
{
    public interface IStor<T>
    {
        IList<T> ListInformation();
    }
}
