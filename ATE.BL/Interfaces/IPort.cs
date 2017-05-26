using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Classes;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;

namespace ATE.BL.Interfaces
{
    public interface IPort
    {
        PortState PortState { get; }
        bool Connect(Terminal terminal);
        //void ConnectToServer(object sender, EventArgsCall eventArgsCall);
        void AnswerPortEvent(object sender, EventArgsAnswer e);
        bool Disconnect(Terminal terminal);
        bool Blocked(Terminal terminal);
        event EventHandler<EventArgsCall> CallEvent;

    }
}
