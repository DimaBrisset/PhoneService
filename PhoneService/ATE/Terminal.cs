using PhoneService.Args;
using PhoneService.Enum;

namespace PhoneService.ATE
{
    internal class Terminal
    {
        private int _number;
        private Port _port;
        private Guid _id;

        public event EventHandler<CallEventARGS> CallEvent;
        public event EventHandler<AnswerEventARGS> AnswerEvent;
        public event EventHandler<EndEventARGS> EndEvent;

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
        protected virtual void EventEnd(Guid id)
        {
            EndEvent?.Invoke(this, new EndEventARGS(id, _number));
        }
        public virtual void EventCall(int targetPhoneNumber)
        {
            CallEvent?.Invoke(this, new CallEventARGS(_number, targetPhoneNumber));
        }
        protected virtual void EventAnswer(int targetPhoneNumber, StatusCall statusCall, Guid id)
        {
            AnswerEvent?.Invoke(this, new AnswerEventARGS(_number, targetPhoneNumber, statusCall, id));
        }


        public void Call(int targetPhoneNumber)
        {
            EventCall(targetPhoneNumber);
        }
        public void EndCall()
        {
            EventEnd(_id);
        }



    }
}
