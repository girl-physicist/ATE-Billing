using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;

namespace ATE.BL.Interfaces
{
  public  interface ITerminal
    {
        TerminalState TerminalState { get; }
        int TelephonNumber { get; }
        IPort Port { get; }
        
    }
}
