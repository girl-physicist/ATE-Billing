﻿using Billing.BL.Enums;

namespace Billing.BL.Classes
{
    public class TariffPlane
    {
        public int SubscriptionFee { get; }
        public int CostOfCallPerMinute { get; }
        public int FreeMinutesInMonth { get; }
        public TariffType TariffType { get; }

        public TariffPlane(TariffType tariffType)
        {
            TariffType = tariffType;
            switch (TariffType)
            {
                case TariffType.Tarif1:
                {
                    SubscriptionFee = 10;
                    FreeMinutesInMonth = 0;
                    CostOfCallPerMinute = 3;
                    break;
                }
                case TariffType.Tarif2:
                {
                    SubscriptionFee = 20;
                    FreeMinutesInMonth = 10;
                    CostOfCallPerMinute = 2;
                    break;
                }
                case TariffType.Tarif3:
                {
                    SubscriptionFee = 30;
                    FreeMinutesInMonth = 15;
                    CostOfCallPerMinute = 1;
                    break;
                }
                default:
                {
                    SubscriptionFee = 0;
                    FreeMinutesInMonth = 0;
                    CostOfCallPerMinute = 0;
                    break;
                }
            }
        }
    }
}