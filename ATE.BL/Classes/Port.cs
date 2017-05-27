using System;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Port : IPort
    {
        public bool Flag;
        private PortState _portState;
        public PortState PortState { get => _portState; set => _portState = value; }
        public Port()
        {
           PortState = PortState.Disсonnected;
        }
        public event EventHandler<EventArgsCall> CallPortEvent;
        public event EventHandler<EventArgsAnswer> AnswerPortEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;
        public event EventHandler<EventArgsCall> CallEvent;
        public bool Connect(Terminal terminal)
        {
            if (PortState == PortState.Disсonnected)
            {
                PortState = PortState.Connected;
                Flag = true;
                terminal.OutgoingCallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndCallEvent += EndCall;
            }
            return Flag;
        }
        public bool Disconnect(Terminal terminal)
        {
            if (PortState == PortState.Connected)
            {
                PortState = PortState.Disсonnected;
                Flag = false;
                terminal.OutgoingCallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndCallEvent -= EndCall;
            }
            return false;
        }
        public bool Blocked(Terminal terminal)
        {
            if (PortState != PortState.Blocked)
            {
                PortState = PortState.Blocked;
                Flag = false;
                terminal.OutgoingCallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndCallEvent -= EndCall;
            }
            return false;
        }

        private void CallingTo(object sender, EventArgsCall e)
        {
            OnCallEvent(e.TelephoneNumber, e.TargetTelephoneNumber);
        }
        protected virtual void OnCallEvent(int number, int targetNumber)
        {
            CallEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        
        protected virtual void OnCallPortEvent(int number, int targetNumber)
        {
            CallPortEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        protected virtual void OnCallPortEvent(int number, int targetNumber,Guid id)
        {
            CallPortEvent?.Invoke(this, new EventArgsCall(number, targetNumber,id));
        }
        public void IncomingCall(int number, int targetNumber)
        {
            OnCallPortEvent(number, targetNumber);
        }
        public void IncomingCall(int number, int targetNumber,Guid id)
        {
            OnCallPortEvent(number, targetNumber,id);
        }
        protected virtual void OnAnswerPortEvent(int number, int targetNumber, CallState state)
        {
            AnswerPortEvent?.Invoke(this, new EventArgsAnswer(number,targetNumber,state));
        }
        public void AnswerCall(int number, int targetNumber, CallState state)
        {
            OnAnswerPortEvent(number, targetNumber, state);
        }
        protected virtual void OnAnswerPortEvent(int number, int targetNumber, CallState state,Guid id)
        {
            AnswerPortEvent?.Invoke(this, new EventArgsAnswer(number, targetNumber, state,id));
        }
        public void AnswerCall(int number, int targetNumber, CallState state,Guid id)
        {
            OnAnswerPortEvent(number, targetNumber, state,id);
        }
        protected virtual void OnAnswerEvent(EventArgsAnswer e)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(
                e.TelephoneNumber,
                e.TargetTelephoneNumber,
                e.StateInCall));
        }
        private void AnswerTo(object sender, EventArgsAnswer e)
        {
            OnAnswerEvent(e);
        }
        protected virtual void OnEndCallEvent( Guid id ,int number)
        {
            EndCallEvent?.Invoke(this,new EventArgsEndCall(id,number));
        }
        private void EndCall(object sender, EventArgsEndCall e)
        {
            OnEndCallEvent(e.Id, e.TelephoneNumber);
        }

       
    }
}
