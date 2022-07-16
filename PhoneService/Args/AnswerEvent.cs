using PhoneService.Enum;

namespace PhoneService.Args
{
    internal class AnswerEvent:EventArgs
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }

        public StatusCall CallStatus;
        private int number;
        private object targetNumber;
        private object state;

        public AnswerEvent(Guid id, int phoneNumber, int targetPhoneNumber, StatusCall callStatus)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CallStatus = callStatus;
        }

        public AnswerEvent(int phoneNumber, int targetPhoneNumber, StatusCall callStatus,Guid id)
        {
         
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CallStatus = callStatus;
            Id = id;
        }

        
    }
}
