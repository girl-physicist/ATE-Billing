using System;
using Billing.BL.Enums;
using Billing.BL.Interfaces;


namespace Billing.BL.Classes
{
    public class Contract : IContract
    {
        private static readonly Random Rnd = new Random();
        public ISubscriber Subscriber { get; }
        public int Number { get; }
        public DateTime DateOfConclusion { get; }
        public TariffPlane Tariff { get; private set; }
        private DateTime _lastTariffUpdateDate;

        public Contract(ISubscriber subscriber, TariffType type, DateTime dateOfConclusion)
        {
            Subscriber = subscriber;
            DateOfConclusion = dateOfConclusion;
            Number = Rnd.Next(100, 999);
            Tariff = new TariffPlane(type);
            _lastTariffUpdateDate = DateTime.Now.Date;
        }
        public bool ChangeTariff(TariffType tariffType)
        {
            if (DateTime.Now.AddMonths(-1) < _lastTariffUpdateDate) return false;
            _lastTariffUpdateDate = DateTime.Now;
            Tariff = new TariffPlane(tariffType);
            return true;
        }
        public bool ChangeTariff(TariffType tariffType, DateTime lastDate)
        {
           if (DateTime.Now.AddMonths(-1).Date < lastDate) return false;
            _lastTariffUpdateDate = DateTime.Now.Date;
            Tariff = new TariffPlane(tariffType);
            return true;
        }
    }
}
