using System;
using Billing.BL.Enums;
using Billing.BL.Interfaces;


namespace Billing.BL.Classes
{
  public  class Contract:IContract
    {
        private static readonly Random Rnd = new Random();
        public ISubscriber Subscriber { get; }
        public int Number { get; }
       public TariffPlane Tariff { get; private set; }
        private DateTime _lastTariffUpdateDate;

        public Contract(ISubscriber subscriber,TariffType type)
        {
            Subscriber = subscriber;
           // Tariff = tariff;
            Subscriber = subscriber;
            Number = Rnd.Next(100, 999);
            Tariff = new TariffPlane(type);
        }

       
        public bool ChangeTariff(TariffType tariffType)
        {
            if (DateTime.Now.AddMonths(-1) >= _lastTariffUpdateDate)
            {
                _lastTariffUpdateDate = DateTime.Now;
                Tariff = new TariffPlane(tariffType);
                /////////////////////////////////////////////////////////////////
                Console.WriteLine("Tariff has changed!");
                return true;
            }
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("Wait until the end of the month!");
            return false;
        }
    }
}
