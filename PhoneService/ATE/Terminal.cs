using PhoneService.Args;
using PhoneService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.ATE
{
    internal class Terminal
    {
        private int _number;
        private Port _port;
        private Guid _id;

        public event EventHandler<CallEvent> CallEvent;
        public event EventHandler<AnswerEvent> AnswerEvent;
        public event EventHandler<EndEvent> EndEvent;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Terminal(int number, Port port)
        {
            _number = number;
            _port = port;

        }
        protected virtual void RaiseEndCallEvent(Guid id)
        {
            EndEvent?.Invoke(this, new EndEvent(id, _number));
        }
        public virtual void EventCall(int targetPhoneNumber)
        {
            CallEvent?.Invoke(this, new CallEvent(_number, targetPhoneNumber));
        }
        protected virtual void EventAnswer(int targetPhoneNumber, StatusCall statusCall, Guid id)
        {
            AnswerEvent?.Invoke(this, new AnswerEvent(_number, targetPhoneNumber, statusCall, id));
        }

     






    }
}
