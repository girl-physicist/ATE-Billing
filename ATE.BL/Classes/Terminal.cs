using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Terminal : ITerminal
    {
        public TerminalState TerminalState { get; }
        private readonly int _number;
        public int TelephonNumber => _number;
        private readonly IPort _terminalPort;
        public IPort Port => _terminalPort;
        public Terminal(int number, IPort port)
        {
            _number = number;
            _terminalPort = port;
        }
        public event EventHandler<EventArgsCall> OutgoingCallEvent;
        // public event EventHandler<EventArgsAnswer> AnswerEvent;
        //  public event EventHandler<EventArgsEndCall> EndCallEvent;
      protected virtual void OnOutgoingCallEvent(int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new EventArgsCall(_number, targetNumber));
        }
        public void Call(int targetNumber)
        {
            OnOutgoingCallEvent(targetNumber);
        }
        public void ConnectToPort()
        {
            if (_terminalPort.Connect(this))
            {
               // _terminalPort.CallPortEvent += TakeIncomingCall;
               // _terminalPort.AnswerPortEvent += TakeAnswer;
            }
        }
    }
}
