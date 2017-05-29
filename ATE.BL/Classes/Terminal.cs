using System;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Terminal : ITerminal
    {
        public int TelephonNumber { get; }
        public IPort Port { get; }
        private readonly Helper _help = new Helper();
        public Terminal(int number, IPort port)
        {
            TelephonNumber = number;
            Port = port;
        }
        public void ConnectToPort()
        {
            if (Port.Connect(this))
            {
                Port.CallPortEvent += TakeIncomingCall;
                Port.AnswerPortEvent += TakeAnswer;
            }
        }
        public void DisconnectFromPort()
        {
            if (Port.Disconnect(this))
            {
                Port.CallPortEvent -= TakeIncomingCall;
                Port.AnswerPortEvent -= TakeAnswer;
            }
        }
        public event EventHandler<EventArgsCall> OutgoingCallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;
        public void Call(int targetNumber)
        {
            if (targetNumber != TelephonNumber)
            { OutgoingCallEvent?.Invoke(this, new EventArgsCall(TelephonNumber, targetNumber)); }
            else
            {
                _help.GetMessageAboutCallYourself(targetNumber);
            }
        }
        public void AnswerToCall(int target, CallState state)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(TelephonNumber, target, state));
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
            EndCallEvent?.Invoke(this, new EventArgsEndCall(TelephonNumber));
        }
        public void TakeAnswer(object sender, EventArgsAnswer e)
        {
            _help.GetMessageAboutAnswer(e.StateInCall, e.TelephoneNumber, e.TargetTelephoneNumber);
        }
    }
}
