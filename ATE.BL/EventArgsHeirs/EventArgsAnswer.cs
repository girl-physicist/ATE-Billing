using System;
using ATE.BL.Enums;

namespace ATE.BL.EventArgsHeirs
{
   public class EventArgsAnswer : EventArgs, IEventArgsCalling
    {
        public int TelephoneNumber { get; }
        public int TargetTelephoneNumber { get; }
        public Guid Id { get; }
        public CallState StateInCall;
     
        public EventArgsAnswer(int number, int target, CallState state)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            StateInCall = state;
        }
        public EventArgsAnswer(int number, int target, CallState state, Guid id)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            StateInCall = state;
            Id = id;
        }
    }
}
