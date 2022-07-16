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
        public event EventHandler<CallEventARGS> CallEvent;
        public event EventHandler<AnswerEventARGS> AnswerEvent;
        public event EventHandler<EndEventARGS> EndEvent;

        public event EventHandler<CallEventARGS> PortCallEvent;
        public event EventHandler<AnswerEventARGS> PortAnswerEvent;

        public Port()
        {
            PortStatus = StatusPort.Disconnect;
        }

        public virtual void EventCalling(int number, int targetPhoneNumber)
        {
            CallEvent?.Invoke(this, new CallEventARGS(number, targetPhoneNumber));
        }
        public virtual void EventEndCall(Guid id, int number)
        {
            EndEvent?.Invoke(this, new EndEventARGS(id, number));
        }
        public virtual void EventInCall(int number, int targetPhoneNumber)
        {
            PortCallEvent?.Invoke(this, new CallEventARGS(number, targetPhoneNumber));
        }
        public virtual void EventInCall(int number, int targetPhoneNumber, Guid id)
        {
            PortCallEvent?.Invoke(this, new CallEventARGS(number, targetPhoneNumber, id));
        }
        public virtual void EventAnswerCall(int number, int targetPhoneNumber, StatusCall statusCall)
        {
            PortAnswerEvent?.Invoke(this, new AnswerEventARGS(number, targetPhoneNumber, statusCall));
        }
        public virtual void EventAnswerCall(int number, int targetPhoneNumber, StatusCall statusCall, Guid id)
        {
            PortAnswerEvent?.Invoke(this, new AnswerEventARGS(number, targetPhoneNumber, statusCall, id));
        }
        protected virtual void EventAnswer(AnswerEventARGS eventARGS)
        {
            AnswerEvent?.Invoke(this, new AnswerEventARGS(
                                 eventARGS.PhoneNumber,
                                 eventARGS.TargetPhoneNumber,
                                 eventARGS.CallStatus,
                                 eventARGS.Id));
        }
        public void InCall(int number, int targetPhoneNumber)
        {
            EventInCall(number, targetPhoneNumber);
        }
        public void InCall(int number, int targetPhoneNumber, Guid id)
        {
            EventInCall(number, targetPhoneNumber, id);
        }
        public void AnswerCall(int number, int targetPhoneNumber, StatusCall statusCall)
        {
            EventAnswerCall(number, targetPhoneNumber, statusCall);
        }
        public void AnswerCall(int number, int targetPhoneNumber, StatusCall statusCall, Guid id)
        {
            EventAnswerCall(number, targetPhoneNumber, statusCall, id);
        }


        private void CallTo(object sender, CallEventARGS e)
        {
            EventCalling(e.PhoneNumber, e.TargetPhoneNumber);
        }
        private void AnswerTo(object sender, AnswerEventARGS e)
        {
            EventAnswer(e);
        }
        private void EndCall(object sender, EndEventARGS e)
        {
            EventEndCall(e.Id, e.PhoneNumber);
        }

        public bool Disconected(Terminal terminal)
        {
            if (PortStatus == StatusPort.Connect)
            {
                PortStatus = StatusPort.Disconnect;
                terminal.CallEvent -= CallTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndEvent -= EndCall;
                IsConnected = false;

            }
            return IsConnected;
        }
        public bool Connect(Terminal terminal)
        {
            if (PortStatus == StatusPort.Disconnect)
            {
                PortStatus = StatusPort.Connect;
                terminal.CallEvent += CallTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndEvent += EndCall;
                IsConnected = true;

            }
            return IsConnected;
        }


    }
}
