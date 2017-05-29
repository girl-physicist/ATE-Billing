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
        public DateTime Date { get; }
        public DateTime CallDuration { get; }
        public int Cost { get; }

        public ReportRecord(int number, CallType type, DateTime date, DateTime callDuration, int cost)
        {
            Number = number;
            CallType = type;
            Date = date;
            CallDuration = callDuration;
            Cost = cost;
        }
    }
}
