using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
   public class EventArgsCallToPort:EventArgsCall
    {
        public DateTime StartCall { get; }
        public EventArgsCallToPort(int number, int target, DateTime startCall) : base(number, target)
        {
            StartCall = startCall;
        }
    }
}
