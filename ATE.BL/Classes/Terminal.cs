using System;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Terminal : ITerminal
    {
        //public TerminalState TerminalState { get; }

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
        public void ConnectToPort()
        {
            if (_terminalPort.Connect(this))
            {
                 _terminalPort.CallPortEvent += TakeIncomingCall;
                 _terminalPort.AnswerPortEvent += TakeAnswer;
            }
        }
        public event EventHandler<EventArgsCall> OutgoingCallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;
        protected virtual void OnOutgoingCallEvent(int targetNumber)
        {
            OutgoingCallEvent?.Invoke(this, new EventArgsCall(_number, targetNumber));
        }
        public void Call(int targetNumber)
        {
            OnOutgoingCallEvent(targetNumber);
        }
        protected virtual void OnAnswerEvent(int targetNumber, CallState state, Guid id)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(_number, targetNumber, state,id));
        }
        public void AnswerToCall(int target, CallState state, Guid id)
        {
            OnAnswerEvent(target, state,id);
        }
        public void TakeIncomingCall(object sender,EventArgsCall e)
        {
            _id = e.Id;
            Helper help = new Helper();
            var param = help.GetAnswer(e.TelephoneNumber, e.TargetTelephoneNumber);
            switch (param)
            {
                case "Answer":
                    AnswerToCall(e.TelephoneNumber, CallState.Answered, e.Id);
                    break;
                case "Reject":
                    EndCall();
                    break;
            }
        }
       protected virtual void OnEndCallEvent(Guid id)
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(id, _number));
        }
        public void EndCall()
        {
            OnEndCallEvent(_id);
        }
        public void TakeAnswer(object sender,EventArgsAnswer e)
        {
            switch (e.StateInCall)
            {
                case CallState.Answered:
                    Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", e.TelephoneNumber, e.TargetTelephoneNumber);
                    break;
                default:
                    Console.WriteLine("Terminal with number: {0}, have rejected call", e.TelephoneNumber);
                    break;
            }
           // return e.StateInCall;
        }
     }
}
