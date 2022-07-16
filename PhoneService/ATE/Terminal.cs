using PhoneService.Args;
using PhoneService.Enum;

namespace PhoneService.ATE
{
    public class Terminal
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
     


        public virtual void EventEnd(Guid id)
        {
            EndEvent?.Invoke(this, new EndEventARGS(id, _number));
        }
        public virtual void EventCall(int targetPhoneNumber)
        {
            CallEvent?.Invoke(this, new CallEventARGS(_number, targetPhoneNumber));
        }
        public virtual void EventAnswer(int targetPhoneNumber, StatusCall statusCall, Guid id)
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

        public void PickUpPhone(object sender, AnswerEventARGS e)// TakeAnswer
        {
            _id = e.Id;
            if (e.CallStatus == StatusCall.Answer)
            {
                Console.WriteLine($"Номер: {e.PhoneNumber}, отвечает: {e.TargetPhoneNumber}");
            }
            else
            {
                Console.WriteLine($"Сбросил звонок: {e.PhoneNumber}");
            }
        }
        public void CallAnswered(int targetPhoneNumber, StatusCall statusCall, Guid id)//AnswerToCall
        {
            EventAnswer(targetPhoneNumber, statusCall, id);
        }
        public void TakeIncomingCall(object sender, CallEventARGS e)
        {
            bool isConnect = true;
            _id = e.Id;
            Console.WriteLine($"Звонит: {e.PhoneNumber} на номер {e.TargetPhoneNumber}");
            while (isConnect == true)
            {
                Console.WriteLine("Ответить? y/n");
                char key = Console.ReadKey().KeyChar;
                if (key == 'y')
                {
                    isConnect = false;
                    Console.WriteLine();
                    EventAnswer(e.PhoneNumber, StatusCall.Answer, e.Id);
                }
                else if (key == 'n')
                {
                    isConnect = false;
                    Console.WriteLine();
                    EndCall();
                }
                else
                {
                    isConnect = true;
                    Console.WriteLine();
                }
            }
        }
        public void ConnectedPort()
        {
            if (_port.Connect(this))
            {
                _port.CallEvent += TakeIncomingCall;
                _port.PortAnswerEvent += PickUpPhone;

            }
        }

    }
}
