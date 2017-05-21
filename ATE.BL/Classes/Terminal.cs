using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
   public class Terminal:ITerminal
    {
        private int number;
        private Port newPort;

        public Terminal(TerminalState terminalState, int telephonNumber, IPort port)
        {
            TerminalState = terminalState;
            TelephonNumber = telephonNumber;
            Port = port;
        }

        public Terminal(int number, Port newPort)
        {
            this.number = number;
            this.newPort = newPort;
        }

        public TerminalState TerminalState { get; }
        public int TelephonNumber { get; }
        public IPort Port { get; }

        public void Call(int number)
        {
            throw new NotImplementedException();
        }

        public void AnswerCall()
        {
            throw new NotImplementedException();
        }

        public void RejectCall()
        {
            throw new NotImplementedException();
        }

        public void EndCall()
        {
            throw new NotImplementedException();
        }
    }
}
