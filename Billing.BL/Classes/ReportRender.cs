using System.Collections.Generic;
using System.Linq;
using Billing.BL.Enums;
using Billing.BL.Interfaces;

namespace Billing.BL.Classes
{
    public class ReportRender : IReportRender
    {
        public void Render(Report report)
        {
        }
        public IEnumerable<ReportRecord> SortCalls(Report report, SortingType sortType)
        {
            var rep = report.GetRecords();
            switch (sortType)
            {
                case SortingType.ByCallType:
                    return rep.
                        OrderBy(x => x.CallType).
                        ToList();
                case SortingType.ByDateOfCall:
                    return rep.
                        OrderBy(x => x.Date).
                        ToList();
                case SortingType.ByCost:
                    return rep
                        .OrderBy(x => x.Cost)
                        .ToList();
                case SortingType.ByNumber:
                    return rep.
                        OrderBy(x => x.Number).
                        ToList();
                default:
                    return rep;
            }
        }
    }
}
