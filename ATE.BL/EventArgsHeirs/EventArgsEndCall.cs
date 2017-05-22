using System;

namespace ATE.BL.EventArgsHeirs
{
  public  class EventArgsEndCall:EventArgs, IEventArgsCalling
    {
        public Guid Id { get; }
        public int TelephoneNumber { get;  }
        public int TargetTelephoneNumber { get; protected set; }

        public EventArgsEndCall(Guid id, int number)
        {
            Id = id;
            TelephoneNumber = number;
        }
    }
}
