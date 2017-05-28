using System;

namespace ATE.BL.Classes
{
    public class CallInfo
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }
        public DateTime Date { get; }
        public DateTime TimeStartCall { get; set; }
        public DateTime TimeEndCall { get; set; }
        public CallInfo(int myNumber, int targetNumber, DateTime date, DateTime beginCall, DateTime endCall)
        {
            CallerNumber = myNumber;
            TargetNumber = targetNumber;
            Date = date;
            TimeStartCall = beginCall;
            TimeEndCall = endCall;
        }
        public CallInfo()
        {
        }
    }
}
