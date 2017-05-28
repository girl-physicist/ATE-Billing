using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;
using Billing.BL.Interfaces;

namespace Billing.BL.Classes
{
    public class Billing : IBilling
    {
       private IDictionary<int, IContract> BillingDictionary { get; set; }
        private ICollection<CallInfo> _storage;
        public Billing()
        {
            _storage = new List<CallInfo>();
            BillingDictionary = new Dictionary<int, IContract>();
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
            BillingDictionary.Add(contract.Number, contract);
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
                if (call.CallerNumber == telephoneNumber)
                {
                    callType = CallType.OutgoingCall;
                    number = call.TargetNumber;
                }
                else
                {
                    callType = CallType.IncomingСall;
                    number = call.CallerNumber;
                }
                var cost = call.GetCost(BillingDictionary.Where(x => x.Key == number).Select(x => x.Value).ElementAt(0)
                    , call.TimeStartCall, call.TimeEndCall);
                var record = new ReportRecord(callType, number, call.TimeStartCall,
                    new DateTime((call.TimeEndCall - call.TimeStartCall).Ticks), cost,call.TargetNumber);
                report.AddRecord(record);
            }
            return report;
        }

       
    }
}
