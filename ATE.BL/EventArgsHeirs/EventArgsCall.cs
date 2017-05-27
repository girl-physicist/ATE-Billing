using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
    public class EventArgsCall : EventArgs, IEventArgsCalling
    {
        public int TelephoneNumber { get;  }
        public int TargetTelephoneNumber { get;  }
       public Guid Id { get; }
        public EventArgsCall(int number, int target)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
        }
        public EventArgsCall(int number, int target, Guid id)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            Id = id;
        }
    }
}
