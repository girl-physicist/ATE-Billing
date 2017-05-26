using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Classes;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;

namespace ATE.BL.Interfaces
{
  public  interface ITerminal
    {
        TerminalState TerminalState { get; }
        int TelephonNumber { get; }
        IPort Port { get; }
        void Call(int targetNumber);
        void ConnectToPort();


    }
}
