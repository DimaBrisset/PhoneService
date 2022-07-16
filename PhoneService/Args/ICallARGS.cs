namespace PhoneService.Args
{
    public interface ICallARGS
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public int TargetPhoneNumber { get; set; }
    }
}
