//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ATE.BL.Enums;
//using Billing.BL.Interfaces;

//namespace Billing.BL.Classes
//{
//  public  class Billing:IBilling
//    {
//        private IStorage<CallInformation> _storage;
//        public Billing(IStorage<CallInformation> storage)
//        {
//            _storage = storage;
//        }

//        public Report GetReport(int telephoneNumber)
//        {
//            var calls = _storage.GetInfoList().
//                Where(x => x.MyNumber == telephoneNumber || x.TargetNumber == telephoneNumber).
//                ToList();
//            var report = new Report();

//            foreach (var call in calls)
//            {
//                CallType callType;
//                int number;
//                if (call.MyNumber == telephoneNumber)
//                {
//                    callType = CallType.OutgoingCall;
//                    number = call.TargetNumber;
//                }
//                else
//                {
//                    callType = CallType.IncomingСall;
//                    number = call.MyNumber;
//                }
//                var record = new ReportRecord(callType, number, call.BeginCall, 
//                    new DateTime((call.EndCall - call.BeginCall).Ticks), call.Cost);   
//                report.AddRecord(record);
//            }
//            return report;
//        }

//    }
//}
