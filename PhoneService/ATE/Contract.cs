namespace PhoneService.ATE
{
    internal class ContractInformation
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }
        public DateTime StartCall { get; set; }
        public DateTime EndCall { get; set; }
        public int Amount { get; set; }

        public ContractInformation(int phoneNumber, int targetPhoneNumber, DateTime startCall)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            StartCall = startCall;

        }

    }
}
