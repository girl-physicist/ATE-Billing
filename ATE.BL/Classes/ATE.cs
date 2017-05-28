using System;
using System.Collections.Generic;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class ATE : IATE
    {
        private Billing.BL.Classes.Billing Billing { get; }
        public delegate void SentData(Billing.BL.Classes.CallInfo callInfo);
        public event SentData SentDataEvent;
        readonly Helper _help = new Helper();
        private IDictionary<int, IPort> _usersData;
        private CallInfo _callInfo;
        public ATE(Billing.BL.Classes.Billing billing)
        {
            Billing = billing;
            _usersData = new Dictionary<int, IPort>();
            _callInfo = new CallInfo();
            SentDataEvent += Billing.AddCallInfo;
        }
        public CallInfo GetInfoList()
        {
            return _callInfo;
        }
        public void AddUsersData(ITerminal terminal)
        {
            var newPort = terminal.Port;
            newPort.CallEvent += CallingTo;
            newPort.AnswerEvent += CallingTo;
            newPort.EndCallEvent += CallingTo;
            _usersData.Add(terminal.TelephonNumber, newPort);
        }
        public void CallingTo(object sender, IEventArgsCalling e)
        {
            if (_usersData.ContainsKey(e.TargetTelephoneNumber) && e.TargetTelephoneNumber != e.TelephoneNumber
                || e is EventArgsEndCall)
            {
                IPort targetPort;
                IPort port;
                if (e is EventArgsEndCall)
                {
                    var callListFirst = _callInfo;
                    if (callListFirst.CallerNumber == e.TelephoneNumber)
                    {
                        targetPort = _usersData[callListFirst.TargetNumber];
                        port = _usersData[callListFirst.CallerNumber];
                    }
                    else
                    {
                        port = _usersData[callListFirst.TargetNumber];
                        targetPort = _usersData[callListFirst.CallerNumber];
                    }
                }
                else
                {
                    targetPort = _usersData[e.TargetTelephoneNumber];
                    port = _usersData[e.TelephoneNumber];
                }
                if (targetPort.PortState == PortState.Connected && port.PortState == PortState.Connected)
                {
                    CallInfo inf;
                    if (e is EventArgsAnswer)
                    {
                        var answerArgs = (EventArgsAnswer)e;
                        targetPort.AnswerCall(answerArgs.TelephoneNumber, answerArgs.TargetTelephoneNumber, answerArgs.StateInCall);
                    }
                    if (e is EventArgsCall)
                    {
                        var callArgs = (EventArgsCall)e;
                        inf = new CallInfo(
                                 callArgs.TelephoneNumber,
                                 callArgs.TargetTelephoneNumber,
                                 DateTime.Now, DateTime.Now, DateTime.Now);
                        _callInfo = inf;
                        targetPort.IncomingCall(callArgs.TelephoneNumber, callArgs.TargetTelephoneNumber);
                    }
                    if (e is EventArgsEndCall)
                    {
                        var args = (EventArgsEndCall)e;
                        inf = _callInfo;
                        inf.TimeEndCall = DateTime.Now;
                        targetPort.AnswerCall(args.TelephoneNumber, args.TargetTelephoneNumber, CallState.Rejected);
                        SentDataEvent?.Invoke(new Billing.BL.Classes.CallInfo(GetInfoList().CallerNumber, GetInfoList().TargetNumber
                            , GetInfoList().Date, GetInfoList().TimeStartCall, GetInfoList().TimeEndCall));
                        }
                }
                else
                {
                    _help.GetMessageAboutCallToDisconnectTerminal(e.TargetTelephoneNumber);
                }
            }
            else if (!_usersData.ContainsKey(e.TargetTelephoneNumber))
            {
                _help.GetMessageAboutNonexistentNumber(e.TargetTelephoneNumber);
            }
        }
    }
}











