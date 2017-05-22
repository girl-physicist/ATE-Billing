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
        private readonly Port _terminalPort;
        public IPort Port => _terminalPort;
        private Guid _id;
        public Terminal(int number, Port port)
        {
            _number = number;
            _terminalPort = port;
        }
        public event EventHandler<EventArgsCall> CallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;


        protected virtual void OnCallEvent(EventArgsCall e)
        {
            CallEvent?.Invoke(this, e);
        }

        protected virtual void OnAnswerEvent(EventArgsAnswer e)
        {
            AnswerEvent?.Invoke(this, e);
        }

        protected virtual void OnEndCallEvent(EventArgsEndCall e)
        {
            EndCallEvent?.Invoke(this, e);
        }
    }
}
