using System;
using System.Collections.Generic;
using System.Linq;
using Billing.BL.Enums;
using Billing.BL.Interfaces;

namespace Billing.BL.Classes
{
    public class Billing : IBilling
    {
        private readonly IDictionary<int, IContract> _billingDictionary;
        private readonly ICollection<CallInfo> _storage;
        public Billing()
        {
            _storage = new List<CallInfo>();
            _billingDictionary = new Dictionary<int, IContract>();
        }
        public void AddCallInfo(CallInfo obj)
        {
            _storage.Add(obj);
        }
        public ICollection<CallInfo> GetInfoList()
        {
            return _storage;
        }
        public void RegisterContract(IContract contract)
        {
            _billingDictionary.Add(contract.Number, contract);
        }
        public void TerminateContract(IContract contract)
        {
            _billingDictionary.Remove(contract.Number);
        }
        public Report GetReport(int telephoneNumber)
        {
            var calls = GetInfoList().
                Where(x => x.CallerNumber == telephoneNumber || x.TargetNumber == telephoneNumber).
                ToList();
            var report = new Report();
            foreach (var call in calls)
            {
                CallType callType;
                int number;
                int cost;
                if (call.CallerNumber == telephoneNumber)
                {
                    callType = CallType.OutgoingCall;
                    number = call.TargetNumber;
                    cost = call.GetCost(_billingDictionary.Where(x => x.Key == telephoneNumber).Select(x => x.Value).ElementAt(0)
                        , call.TimeStartCall, call.TimeEndCall);
                }
                else
                {
                    callType = CallType.IncomingСall;
                    number = call.CallerNumber;
                    cost = 0;
                }
                var record = new ReportRecord(number, callType, call.TimeStartCall,
                    new DateTime((call.TimeEndCall - call.TimeStartCall).Ticks), cost);
                report.AddRecord(record);
            }
            return report;
        }
        public int PayInvoice(IContract contract, int monthNumber)
        {
            double summ;
            var listRecords = GetReport(contract.Number).GetRecords();
            var listAllDuration=listRecords.Where(x => x.Date.Month == monthNumber).Where(x=>x.CallType== CallType.OutgoingCall).Select(x => x.CallDuration);
            var allDuration = listAllDuration.Sum(x => Math.Ceiling(((double) x.Hour * 360 + x.Second + x.Minute * 60) / 60));
            var allCallCost= listRecords.Where(x => x.Date.Month == monthNumber).Select(x => x.Cost).Sum();
            allDuration = allDuration < 1 ? 1 : allDuration;
            if (allDuration > contract.Tariff.FreeMinutesInMonth)
            {
                summ = allCallCost+ contract.Tariff.SubscriptionFee- contract.Tariff.FreeMinutesInMonth* contract.Tariff.CostOfCallPerMinute;
            }
            else
            {
                summ = contract.Tariff.SubscriptionFee;
            }
            return (int)summ;
        }
    }
}
