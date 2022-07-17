using PhoneService.Enum;

namespace PhoneService.Args
{
    public class AnswerEventARGS:EventArgs,ICallARGS
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }

        public StatusCall CallStatus;
     
     

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
