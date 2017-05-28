using System;
using Billing.BL.Enums;
using Billing.BL.Interfaces;

namespace Billing.BL.Classes
{
    public class CallInfo
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }
        public DateTime Date { get; }
        public DateTime TimeStartCall { get;  }
        public DateTime TimeEndCall { get; }
        public int Cost { get; }

        public CallInfo(int myNumber, int targetNumber, DateTime date, DateTime beginCall, DateTime endCall, int cost)
        {
            CallerNumber = myNumber;
            TargetNumber = targetNumber;
            Date = date;
            TimeStartCall = beginCall;
            TimeEndCall = endCall;
            Cost = cost;
        }
        public CallInfo(int myNumber, int targetNumber, DateTime date, DateTime beginCall, DateTime endCall)
        {
            CallerNumber = myNumber;
            TargetNumber = targetNumber;
            Date = date;
            TimeStartCall = beginCall;
            TimeEndCall = endCall;
            
        }
        public int GetCost(IContract contract, DateTime timeStartCall, DateTime timeEndCall)
        {
            var sumOfCall = contract.Tariff.CostOfCallPerMinute * TimeSpan.FromTicks((timeEndCall - timeStartCall).Ticks).TotalMinutes;
            return (int)sumOfCall;
           // targetTuple.Item2.Subscriber.RemoveMoney(inf.Cost);
        }
    }
}
