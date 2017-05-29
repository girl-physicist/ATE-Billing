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
                var cost = call.GetCost(_billingDictionary.Where(x => x.Key == number).Select(x => x.Value).ElementAt(0)
                    , call.TimeStartCall, call.TimeEndCall);
                var record = new ReportRecord(number, callType, call.TimeStartCall,
                    new DateTime((call.TimeEndCall - call.TimeStartCall).Ticks), cost);
                report.AddRecord(record);
            }
            return report;
        }
        public int GetInvoiceForPayment(IContract contract)
        {
            for (int i = 1; i <= 12; i++)
            {
                DateTime dateOfPayment = contract.DateOfConclusion.AddMonths(i);
            }
                int invoice = 0;
            return invoice;
        }
    }
}
