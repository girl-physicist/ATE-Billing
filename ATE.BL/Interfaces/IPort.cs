using System;
using ATE.BL.Classes;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;

namespace ATE.BL.Interfaces
{
    public interface IPort
    {
        PortState PortState { get; set; }
        bool Connect(Terminal terminal);
        bool Disconnect(Terminal terminal);
        bool Blocked(Terminal terminal);
        event EventHandler<EventArgsCall> CallEvent;
        event EventHandler<EventArgsCall> CallPortEvent;
        event EventHandler<EventArgsAnswer> AnswerPortEvent;
        event EventHandler<EventArgsAnswer> AnswerEvent;
        event EventHandler<EventArgsEndCall> EndCallEvent;
        void AnswerCall(int number, int targetNumber, CallState state);
        void IncomingCall(int number, int targetNumber);
    }
}
