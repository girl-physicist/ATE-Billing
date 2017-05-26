using System;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class Port : IPort
    {
        public bool Flag;
        public PortState PortState { get; private set; }
        public Port()
        {
            
            PortState = PortState.Disсonnected;
        }

        //public event EventHandler<EventArgsCallToPort> Calling;
        //public void ConnectToServer(object sender, EventArgsCall e)
        // {
        //     Calling += _ate.CallProcessing;
        //     Calling?.Invoke(this, new EventArgsCallToPort(e.TelephoneNumber, e.TargetTelephoneNumber, DateTime.Now));
        // }
        // public event EventHandler<EventArgsAnswer> Answering;
        // public void AnswerPortEvent(object sender, ParamAnswer e)
        // {
        //     switch (e.Param)
        //     {
        //         case "Answer":
        //             Answering?.Invoke(this, new EventArgsAnswer(e.TelephoneNumber, e.TargetTelephoneNumber, CallState.Answered, DateTime.Now));
        //             break;
        //         case "Reject":
        //             Answering?.Invoke(this, new EventArgsAnswer(e.TelephoneNumber, e.TargetTelephoneNumber, CallState.Rejected, DateTime.Now));
        //             break;
        //         default:
        //             break;
        //     }
        // }

        public event EventHandler<EventArgsCall> CallEvent;


        public bool Connect(Terminal terminal)
        {
            if (PortState == PortState.Disсonnected)
            {
                PortState = PortState.Connected;
                Flag = true;
                terminal.OutgoingCallEvent += CallingTo;

            }
            return Flag;
        }
        private void CallingTo(object sender, EventArgsCall e)
        {
            OnCallEvent(e.TelephoneNumber, e.TargetTelephoneNumber);
        }
        protected virtual void OnCallEvent(int number, int targetNumber)
        {
            CallEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        public bool Disconnect(Terminal terminal)
        {
            if (PortState == PortState.Connected)
            {
                PortState = PortState.Disсonnected;
                Flag = false;
               
              
            }
            return false;
        }
        public bool Blocked(Terminal terminal)
        {
            if (PortState != PortState.Blocked)
            {
                PortState = PortState.Blocked;
                Flag = false;
               
             
            }
            return false;
        }

        public void AnswerPortEvent(object sender, EventArgsAnswer e)
        {
            throw new NotImplementedException();
        }
    }
}
