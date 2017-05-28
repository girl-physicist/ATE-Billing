using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.BL.Classes;
using Billing.BL.Enums;

namespace Billing.BL.Interfaces
{
  public  interface IReportRender
    {
        void Render(Report report);
        IEnumerable<ReportRecord> SortCalls(Report report, SortingType sortType);
    }
}
