using System;

namespace ATE.BL.EventArgsHeirs
{
  public  class EventArgsEndCall:EventArgs, IEventArgsCalling
    {
       
        public int TelephoneNumber { get;  }
        public int TargetTelephoneNumber { get; protected set; }

        public EventArgsEndCall( int number)
        {
          
            TelephoneNumber = number;
        }
    }
}
