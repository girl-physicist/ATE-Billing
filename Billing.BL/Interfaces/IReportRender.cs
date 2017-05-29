using System.Collections.Generic;
using Billing.BL.Classes;
using Billing.BL.Enums;

namespace Billing.BL.Interfaces
{
    public interface IReportRender
    {
        void Render(Report report);
        IEnumerable<ReportRecord> SortCalls(Report report, SortingType sortType);
    }
}
