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
        public CallType CallType { get; }
        public int Number { get; }
        public int TargetNumber { get; }
        public DateTime Date { get; }
        public DateTime Time { get;  }
        public int Cost { get;  }

        public ReportRecord(CallType callType, int number, DateTime date, DateTime time, int cost, int targetNumber)
        {
            CallType = callType;
            Number = number;
            Date = date;
            Time = time;
            Cost = cost;
            TargetNumber = targetNumber;
        }
    }
}
