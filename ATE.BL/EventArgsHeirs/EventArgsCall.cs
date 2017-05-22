using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
    public class EventArgsCall : EventArgs, IEventArgsCalling
    {
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }
        public Guid Id { get; private set; }
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
