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
        //Класс-источник сообщения
        public Port()
        {
            PortState = PortState.Disсonnected;
        }
        public bool Connect(Terminal terminal)
        {
            if (PortState == PortState.Disсonnected)
            {
                PortState = PortState.Connected;
                Flag = true;
                terminal.CallEvent += CallingTo;
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
                terminal.CallEvent -= CallingTo;
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
                terminal.CallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndCallEvent -= EndCall;
            }
            return false;
        }

        // тип EventHandler<TEventArgs> — когда аргументы события есть, тогда для них создается отдельный класс — наследник от EventArgs.
        //В случае обработчика событий делегат, на который объект ссылается, помечается ключевым словом event.
        //EventHandler - тип события, который обязательно должен быть типом-делегатом,
        // Создание события на базе стандартного делегата
        public event EventHandler<EventArgsCall> CallPortEvent; // соединение с терминалом
        public event EventHandler<EventArgsAnswer> AnswerPortEvent; // соединение с терминалом
        public event EventHandler<EventArgsCall> CallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;


        protected virtual void OnCallPortEvent(int number, int targetNumber)
        {
            // вызов делегата
            CallPortEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        public void IncomingCall(int number, int targetNumber)
        {
            OnCallPortEvent(number, targetNumber);
        }
        protected virtual void OnCallPortEvent(int number, int targetNumber, Guid id)
        {
            CallPortEvent?.Invoke(this, new EventArgsCall(number, targetNumber, id));
        }
        public void IncomingCall(int number, int targetNumber, Guid id)
        {
            OnCallPortEvent(number, targetNumber, id);
        }
        protected virtual void OnAnswerPortEvent(int number, int targetNumber, CallState state)
        {
            AnswerPortEvent?.Invoke(this, new EventArgsAnswer(number, targetNumber, state));
        }
        public void AnswerCall(int number, int targetNumber, CallState state)
        {
            OnAnswerPortEvent(number, targetNumber, state);
        }
        protected virtual void OnAnswerPortEvent(int number, int targetNumber, CallState state, Guid id)
        {
            AnswerPortEvent?.Invoke(this, new EventArgsAnswer(number, targetNumber, state, id));
        }
        public void AnswerCall(int number, int targetNumber, CallState state, Guid id)
        {
            OnAnswerPortEvent(number, targetNumber, state, id);
        }
        protected virtual void OnCallEvent(int number, int targetNumber)
        {
            CallEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }
        private void CallingTo(object sender, EventArgsCall e)
        {
            OnCallEvent(e.TelephoneNumber, e.TargetTelephoneNumber);
        }
        protected virtual void OnAnswerEvent(int number, int targetNumber, CallState state, Guid id)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(number, targetNumber, state, id));
        }
        private void AnswerTo(object sender, EventArgsAnswer e)
        {
            OnAnswerEvent(e.TelephoneNumber, e.TargetTelephoneNumber, e.StateInCall, e.Id);
        }
        protected virtual void OnEndCallEvent(Guid id, int number)
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(id, number));
        }
        private void EndCall(object sender, EventArgsEndCall e)
        {
            OnEndCallEvent(e.Id, e.TelephoneNumber);
        }















    }
}
