using System;
using System.Collections.Generic;
using System.Linq;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
    public class ATE : IATE
    {
        readonly Helper _help = new Helper();
        private IDictionary<int, IPort> _usersData;
        private CallInfo _callList;

        public ATE()
        {
            _usersData = new Dictionary<int, IPort>();
            _callList = new CallInfo();
        }
        public CallInfo GetInfoList()
        {
            return _callList;
        }
        public void GetUsersData(ITerminal terminal)
        {
            var newPort = terminal.Port;
            newPort.CallEvent += CallingTo;
            newPort.AnswerEvent += CallingTo;
            newPort.EndCallEvent += CallingTo;
            _usersData.Add(terminal.TelephonNumber, newPort);
        }
        public void CallingTo(object sender, IEventArgsCalling e)
        {

            if ((_usersData.ContainsKey(e.TargetTelephoneNumber) && e.TargetTelephoneNumber != e.TelephoneNumber)
                || e is EventArgsEndCall)
            {
                IPort targetPort;
                IPort port;
                if (e is EventArgsEndCall)
                {
                    var callListFirst = _callList;
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
                        _callList = inf;
                        targetPort.IncomingCall(callArgs.TelephoneNumber, callArgs.TargetTelephoneNumber);
                    }
                    if (e is EventArgsEndCall)
                    {
                        var args = (EventArgsEndCall)e;
                        inf = _callList;
                        inf.TimeEndCall = DateTime.Now;
                        targetPort.AnswerCall(args.TelephoneNumber, args.TargetTelephoneNumber, CallState.Rejected);
                        Console.WriteLine("{0} \n,{1} \n,{2} \n,{3} \n,{4} \n,{5} \n"
                            , GetInfoList().CallerNumber
                            , GetInfoList().TargetNumber
                            , GetInfoList().TimeStartCall
                            , GetInfoList().TimeEndCall
                            , GetInfoList().Date
                            , GetInfoList().GetCallDuration(GetInfoList().TimeStartCall, GetInfoList().TimeEndCall)
                           );
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











