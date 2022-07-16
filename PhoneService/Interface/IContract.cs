using PhoneService.Billing;
using PhoneService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Interface
{
    public interface IContract
    {
        User User { get; }
        int Number { get; }
        Tariffs Tariffs { get; }
       

        bool ChangeTariff(TypeTariff typeTariff);

    }
}
