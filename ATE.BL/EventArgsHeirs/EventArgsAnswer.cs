﻿using System;
using ATE.BL.Enums;

namespace ATE.BL.EventArgsHeirs
{    // Расширение библиотечного класса аргументов
    public class EventArgsAnswer : EventArgs, IEventArgsCalling
    {
        public int TelephoneNumber { get; }
        public int TargetTelephoneNumber { get; }
        public CallState StateInCall;
        public EventArgsAnswer(int number, int target, CallState state)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            StateInCall = state;
        }
    }
}
