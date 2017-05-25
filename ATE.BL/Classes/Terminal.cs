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
        private Guid _id;
        public Terminal(int number, IPort port)
        {
            _number = number;
            _terminalPort = port;
        }
        public event EventHandler<EventArgsCall> OutgoingCallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        //  public event EventHandler<EventArgsEndCall> EndCallEvent;

        public void ConnectToPort()
        {
            OutgoingCallEvent += Port.ConnectToServer;
            AnswerEvent += Port.AnswerPortEvent;
        }
        public void OnOutgoingCallEvent(int number, int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        public void OnAnswerEvent(int number, int targetNumber, CallState state, DateTime startCall)
        {
            AnswerEvent?.Invoke(this, new ParamAnswer(number,targetNumber,state,startCall));
        }


    }
}
