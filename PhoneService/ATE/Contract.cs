﻿namespace PhoneService.ATE
{
    internal class Contract
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }
        public DateTime StartCall { get; set; }
        public DateTime EndCall { get; set; }
        public int Amount { get; set; }

        public Contract(int phoneNumber, int targetPhoneNumber, DateTime startCall)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            StartCall = startCall;

        }

    }
}
