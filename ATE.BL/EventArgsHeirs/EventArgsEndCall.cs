using System;

namespace ATE.BL.EventArgsHeirs
{
  public  class EventArgsEndCall:EventArgs, IEventArgsCalling
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }
    }
}
