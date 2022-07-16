using PhoneService.Args;
using PhoneService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.ATE
{
    internal class Port
    {
        public StatusPort PortStatus;
        public bool IsConnected;
        public event EventHandler<CallEvent> CallEvent;
        public event EventHandler<AnswerEvent> AnswerEvent;
        public event EventHandler<EndEvent> EndEvent;


        public event EventHandler<CallEvent> PortCallEvent;
        public event EventHandler<AnswerEvent> PortAnswerEvent;


        public Port()
        {
            PortStatus = StatusPort.Disconnect;
        }


    }
}
