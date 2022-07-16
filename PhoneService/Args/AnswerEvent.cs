using PhoneService.Enum;

namespace PhoneService.Args
{
    internal class AnswerEvent:EventArgs
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }

        public StatusCall CallStatus;
        public AnswerEvent(Guid id, int phoneNumber, int targetPhoneNumber, StatusCall callStatus)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CallStatus = callStatus;
        }

        public AnswerEvent(int phoneNumber, int targetPhoneNumber, StatusCall callStatus)
        {
         
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            CallStatus = callStatus;
        }


    }
}
