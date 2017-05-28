using System;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Terminal : ITerminal
    {
        private readonly int _number;
        public int TelephonNumber => _number;
        private readonly IPort _terminalPort;
        public IPort Port => _terminalPort;
        readonly Helper _help = new Helper();
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
        public void DisconnectFromPort()
        {
            if (_terminalPort.Disconnect(this))
            {
                _terminalPort.CallPortEvent -= TakeIncomingCall;
                _terminalPort.AnswerPortEvent -= TakeAnswer;
            }
        }
        public event EventHandler<EventArgsCall> OutgoingCallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;
        public void Call(int targetNumber)
        {
            if (targetNumber != _number)
            { OutgoingCallEvent?.Invoke(this, new EventArgsCall(_number, targetNumber)); }
            else
            {
                _help.GetMessageAboutCallYourself(targetNumber);
            }
        }
        public void AnswerToCall(int target, CallState state)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(_number, target, state));
        }
        public void TakeIncomingCall(object sender, EventArgsCall e)
        {
            var param = _help.GetAnswer(e.TelephoneNumber, e.TargetTelephoneNumber);
            if (param == "Answer")
                AnswerToCall(e.TelephoneNumber, CallState.Answered/*, e.Id*/);
            else if (param == "Reject")
            {
                EndCall();
            }
        }
        public void EndCall()
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(_number));
        }
        public void TakeAnswer(object sender, EventArgsAnswer e)
        {
            _help.GetMessageAboutAnswer(e.StateInCall, e.TelephoneNumber, e.TargetTelephoneNumber);
        }
    }
}
