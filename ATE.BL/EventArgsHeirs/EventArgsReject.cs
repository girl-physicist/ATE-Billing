using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
  public  class EventArgsReject:EventArgs, IEventArgsCalling
    {
        public int CallerNumber { get; }
        public int TargetNumber { get; }
    }
}
