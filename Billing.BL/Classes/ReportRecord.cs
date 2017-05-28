using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;

namespace Billing.BL.Classes
{
   public class ReportRecord
    {
        public CallType CallType { get; private set; }
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Time { get; private set; }
        public int Cost { get; private set; }

        public ReportRecord(CallType callType, int number, DateTime date, DateTime time, int cost)
        {
            CallType = callType;
            Number = number;
            Date = date;
            Time = time;
            Cost = cost;
        }
    }
}
