﻿using System;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Port : IPort
    {
        private bool _flag;
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
                _flag = true;
                terminal.OutgoingCallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndCallEvent += EndCall;
            }
            return _flag;
        }
        public bool Disconnect(Terminal terminal)
        {
            if (PortState == PortState.Connected)
            {
                PortState = PortState.Disсonnected;
                _flag = false;
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
                _flag = false;
                terminal.OutgoingCallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndCallEvent -= EndCall;
            }
            return false;
        }
        private void CallingTo(object sender, EventArgsCall e)
        {
            CallEvent?.Invoke(this, new EventArgsCall(e.TelephoneNumber, e.TargetTelephoneNumber));
        }
        private void AnswerTo(object sender, EventArgsAnswer e)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(e.TelephoneNumber, e.TargetTelephoneNumber, e.StateInCall));
        }
        private void EndCall(object sender, EventArgsEndCall e)
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(e.TelephoneNumber));
        }
        public void IncomingCall(int number, int targetNumber)
        {
            CallPortEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        public void AnswerCall(int number, int targetNumber, CallState state)
        {
            AnswerPortEvent?.Invoke(this, new EventArgsAnswer(number, targetNumber, state));
        }
    }
}
