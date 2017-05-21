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
        // через event
        void Call(int number);
        void AnswerCall();
        void RejectCall();
        void EndCall();
    }
}
