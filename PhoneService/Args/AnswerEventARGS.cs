using PhoneService.Enum;

namespace PhoneService.Args
{
    internal class AnswerEventARGS:EventArgs
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }

        public StatusCall CallStatus;
        private int number;
        private object targetNumber;
        private object state;

        public AnswerEventARGS(int phoneNumber, int targetPhoneNumber, StatusCall callStatus)
        {
          
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CallStatus = callStatus;
        }

        public AnswerEventARGS(int phoneNumber, int targetPhoneNumber, StatusCall callStatus,Guid id)
        {
         
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CallStatus = callStatus;
            Id = id;
        }

        
    }
}
