using PhoneService.Args;
using PhoneService.ATE;
using PhoneService.Billing;
using PhoneService.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Interface
{
    public interface IAte : IStor<ContractInformation>
    {
        Terminal GetTerminal(IContract contract);
        IContract RegisterContract(User user, TypeTariff typeTariff);
        void CallingTo(object sender, ICallARGS e);


    }
}
