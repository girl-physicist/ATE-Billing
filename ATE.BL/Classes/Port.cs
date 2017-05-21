using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
 public   class Port:IPort
    {
        public Port()
        {
        }

        public Port(PortState portState)
        {
            PortState = portState;
        }

        public PortState PortState { get; }
    }
}
