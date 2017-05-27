using System;

namespace ATE.BL.EventArgsHeirs
{
  public  class EventArgsEndCall:EventArgs, IEventArgsCalling
    {
       
        public int TelephoneNumber { get;  }
        public int TargetTelephoneNumber { get; protected set; }
        public Guid Id { get;  }
        public EventArgsEndCall(  Guid id, int number)
        {
            TelephoneNumber = number;
            Id = id;
        }
    }
}
