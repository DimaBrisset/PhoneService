namespace PhoneService.Billing
{
    public class User
    {
        public string Name { get; private set; }
        public int Balance { get; private set; }

        public User(string name, int balance)
        {
            Name = name;
            Balance = balance;
        }

        public void BalanceAdd(int balance)
        {
            Balance += balance;
        }

        public void BalanceWithdraw(int balance)
        {
            Balance -= balance;
        }


    }
}