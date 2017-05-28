using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.Classes
{
    public class CallInfo
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }
        public DateTime Date { get; }
        public DateTime TimeStartCall { get; set; }
        public DateTime TimeEndCall { get; set; }
        public Guid CallInfoId { get; set; }
      //  public int Cost { get; set; }

        public CallInfo(int myNumber, int targetNumber, DateTime date, DateTime beginCall, DateTime endCall)
        {
            CallerNumber = myNumber;
            TargetNumber = targetNumber;
            Date = date;
            TimeStartCall = beginCall;
            TimeEndCall = endCall;
            CallInfoId = Guid.NewGuid();
        }
        public CallInfo(int myNumber, int targetNumber, DateTime date)
        {
            CallerNumber = myNumber;
            TargetNumber = targetNumber;
            Date = date;
            CallInfoId = Guid.NewGuid();
        }
        public CallInfo()
        {
        }

        public TimeSpan GetCallDuration(DateTime timeStartCall, DateTime timeEndCall)
        {
            return timeEndCall.Subtract(timeStartCall);
        }

    }
}
