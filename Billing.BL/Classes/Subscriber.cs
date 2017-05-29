using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.BL.Interfaces;

namespace Billing.BL.Classes
{
   public class Subscriber:ISubscriber
    {
       public Subscriber(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Money = 50;
            }
        public string FirstName { get; }
        public string LastName { get; }
        public int Money { get; private set; }

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
