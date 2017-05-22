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
 public   class Port:IPort
    {
        public Port()
        {
            PortState = PortState.Disсonnected;
        }

        //public Port(PortState portState)
        //{
        //    PortState = portState;
        //}

       
        public bool Flag;

        public PortState PortState { get;private set; }
        //В случае обработчика событий делегат, на который объект ссылается, помечается ключевым словом event.
        //EventHandler - тип события, который обязательно должен быть типом-делегатом,
        public event EventHandler<EventArgsCall> CallPortEvent;
        public event EventHandler<EventArgsAnswer> AnswerPortEvent;
        public event EventHandler<EventArgsCall> CallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;

       

        public bool Connect(Terminal terminal)
        {
            if (PortState == PortState.Disсonnected)
            {
                PortState = PortState.Connected;
               Flag = true;
                //ПОДПИСКА
            }
            return Flag;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (PortState == PortState.Connected)
            {
                PortState = PortState.Disсonnected;
               Flag = false;
                //ПОДПИСКА
            }
            return false;
        }

        public bool Blocked(Terminal terminal)
        {
            if (PortState != PortState.Blocked)
            {
                PortState = PortState.Blocked;
                Flag = false;
                //ОТПИСКА
            }
            return false;
        }


        protected virtual void OnCallPortEvent(EventArgsCall e)
        {
            CallPortEvent?.Invoke(this, e);
        }

        protected virtual void OnAnswerPortEvent(EventArgsAnswer e)
        {
            AnswerPortEvent?.Invoke(this, e);
        }

        protected virtual void OnCallEvent(EventArgsCall e)
        {
            CallEvent?.Invoke(this, e);
        }

        protected virtual void OnAnswerEvent(EventArgsAnswer e)
        {
            AnswerEvent?.Invoke(this, e);
        }

        protected virtual void OnEndCallEvent(EventArgsEndCall e)
        {
            EndCallEvent?.Invoke(this, e);
        }
    }
}
