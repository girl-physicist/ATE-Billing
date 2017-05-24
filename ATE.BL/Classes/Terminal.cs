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
        public void ConnectToPort()
        {
            if (_terminalPort.Connect(this))
            {
                _terminalPort.CallPortEvent += TakeIncomingCall;
                _terminalPort.AnswerPortEvent += TakeAnswer;
            }
        }
        protected virtual void OnCallEvent(int targetNumber)
        {
            CallEvent?.Invoke(this, new EventArgsCall(_number, targetNumber));
        }
        public void Call(int targetNumber)
        {
            OnCallEvent(targetNumber);
        }
        protected virtual void OnAnswerEvent(int targetNumber, CallState state, Guid id)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(_number, targetNumber, state, id));
        }
        public void AnswerToCall(int target, CallState state, Guid id)
        {
            OnAnswerEvent(target, state, id);
        }
        protected virtual void OnEndCallEvent(Guid id)
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(id, _number));
        }
        public void EndCall()
        {
            OnEndCallEvent(_id);
        }
        public void TakeIncomingCall(object sender, EventArgsCall e)
        {
            bool flag = true;
            _id = e.Id;
            Console.WriteLine("Number: {0} call to number {1}", e.TelephoneNumber, e.TargetTelephoneNumber);
            while (flag == true)
            {
                Console.WriteLine("Answer? Y/N");
                var k = Console.ReadKey().Key;
                if (k == ConsoleKey.Y)
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(e.TelephoneNumber, CallState.Answered, e.Id);
                }
                else if (k == ConsoleKey.N)
                {
                    flag = false;
                    Console.WriteLine();
                    EndCall();
                }
                else
                {
                    Console.WriteLine();
                    flag = true;
                }
            }
        }
        public void TakeAnswer(object sender, EventArgsAnswer e)
        {
            _id = e.Id;
           Console.WriteLine(
                e.StateInCall == CallState.Answered
                    ? "Number: {0}, have answer on call a number: {1}"
                    : "Number: {0}, have rejected call a number: {1}", e.TelephoneNumber, e.TargetTelephoneNumber);
        }
        //public string TakeAnswer(object sender, EventArgsAnswer e)
        //{
        //    //  _id = e.Id;
        //    return e.StateInCall == CallState.Answered ? "Answer" : "Reject";
        //}




    }
}
