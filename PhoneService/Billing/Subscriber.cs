namespace PhoneService
{
    public class Subscriber
    {
        public string FirstName { get; private set; }
   
        public int Money { get; private set; }

        public Subscriber(string firstName)
        {
            FirstName = firstName;
         
            Money = 30;
        }

        public void AddMoney(int money)
        {
            Money += money;
        }

        public void RemoveMoney(int money)
        {
            Money -= money;
        }
    }
}
