using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
    public class EventArgsCall : EventArgs, IEventArgsCalling
    {
        public int CallerNumber => throw new NotImplementedException();

        public int TargetNumber => throw new NotImplementedException();
    }
}
