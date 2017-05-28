//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Billing.BL.Enums;
//using Billing.BL.Interfaces;

//namespace Billing.BL.Classes
//{
//  public  class ReportRender:IReportRender
//    {
//        public void Render(Report report)
//        {
//            foreach (var record in report.GetRecords())
//            {
//                Console.WriteLine("Calls:\n Type {0} |\n Date: {1} |\n Duration: {2:mm:ss} | Cost: {3} | Telephone number: {4}",
//                    record.CallType, record.Date, record.Time, record.Cost, record.Number);
//            }
//        }
//        public IEnumerable<ReportRecord> SortCalls(Report report, SortingType sortType)
//        {
//            var rep = report.GetRecords();
//            switch (sortType)
//            {
//                case SortingType.SortByCallType:
//                    return rep = rep.
//                        OrderBy(x => x.CallType).
//                        ToList();

//                case SortingType.SortByDate:
//                    return rep = rep.
//                        OrderBy(x => x.Date).
//                        ToList();

//                case SortingType.SortByCost:
//                    return rep = rep
//                        .OrderBy(x => x.Cost)
//                        .ToList();

//                case SortingType.SortByNumber:
//                    return rep = rep.
//                        OrderBy(x => x.Number).
//                        ToList();

//                default:
//                    return rep;
//            }
//        }
//    }
//}
