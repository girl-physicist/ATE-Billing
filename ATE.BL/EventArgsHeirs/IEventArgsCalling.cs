using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.EventArgsHeirs
{
   public interface IEventArgsCalling
    {
         int CallerNumber { get; }
         int TargetNumber { get; }
    }
}
