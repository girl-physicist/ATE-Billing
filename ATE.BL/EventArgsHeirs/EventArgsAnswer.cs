using System;
namespace ATE.BL.EventArgsHeirs
{
   public class EventArgsAnswer : EventArgs, IEventArgsCalling
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }
    }
}
