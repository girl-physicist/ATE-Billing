using System;
using Billing.BL.Classes;
using Billing.BL.Enums;

namespace Billing.BL.Interfaces
{
    public interface IContract
    {
        ISubscriber Subscriber { get; }
        TariffPlane Tariff { get; }
        int Number { get; }
        DateTime DateOfConclusion { get; }
        bool ChangeTariff(TariffType tariffType);
        // для проверки возможности изменения тарифа
        bool ChangeTariff(TariffType tariffType, DateTime lastTariffUpdateDate);
    }
}
