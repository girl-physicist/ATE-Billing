namespace Billing.BL.Interfaces
{
    public interface ISubscriber
    {
        string FirstName { get; }
        string LastName { get; }
        int Money { get; }
        void AddMoney(int money);
        void RemoveMoney(int money);
        void GetReport();
    }
}