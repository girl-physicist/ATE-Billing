using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.BL.Enums;

namespace Billing.BL.Classes
{
    public class Report
    {
        private readonly IList<ReportRecord> _listRecords;
        public Report()
        {
            _listRecords = new List<ReportRecord>();
        }
        public void AddRecord(ReportRecord record)
        {
            _listRecords.Add(record);
        }
        public void RemoveRecord(ReportRecord record)
        {
            _listRecords.Remove(record);
        }
        public IList<ReportRecord> GetRecords()
        {
            return _listRecords;
        }
    }
}
