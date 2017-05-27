using System;
using System.Collections.Generic;
using System.Linq;
using ATE.BL.Enums;
using ATE.BL.EventArgsHeirs;
using ATE.BL.Interfaces;

namespace ATE.BL.Classes
{
  public  class ATE:IATE
    {
        private IDictionary<int, Tuple<IPort, ITerminal>> _usersData;
      //  private readonly IDictionary< IPort,ITerminal> _usersData;
        private readonly ICollection<CallInfo> _callList;
        public ATE(IDictionary<int, Tuple<IPort, ITerminal>> usersData)
        {
            _usersData = usersData;
            _callList = new List<CallInfo>();
        }

        public ATE()
        {
            _usersData = new Dictionary<int, Tuple<IPort, ITerminal>>();
            _callList = new List<CallInfo>();
        }
        public ICollection<CallInfo> GetInfoList()
        {
            return _callList;
        }
        
        public void ConnectPortToTerminal(ITerminal terminal)
        {
          var newPort =terminal.Port;
            newPort.CallEvent += CallingTo;
            newPort.AnswerEvent += CallingTo;
            newPort.EndCallEvent += CallingTo;
            _usersData.Add(terminal.TelephonNumber, new Tuple<IPort, ITerminal>(newPort, terminal));
         }

        public void CallingTo(object sender, IEventArgsCalling e)
        {
            if ((_usersData.ContainsKey(e.TargetTelephoneNumber) && e.TargetTelephoneNumber != e.TelephoneNumber)
                || e is EventArgsEndCall)
            {
                CallInfo inf = null;
                IPort targetPort;
                IPort port;
               if (e is EventArgsEndCall)
                {
                    var callListFirst = _callList.First(x => x.Id.Equals(e.Id));
                    if (callListFirst.CallerNumber == e.TelephoneNumber)
                    {
                        targetPort = _usersData[callListFirst.TargetNumber].Item1;
                        port = _usersData[callListFirst.CallerNumber].Item1;
                       }
                    else
                    {
                        port = _usersData[callListFirst.TargetNumber].Item1;
                        targetPort = _usersData[callListFirst.CallerNumber].Item1;
                       }
                }
                else
                {
                    targetPort = _usersData[e.TargetTelephoneNumber].Item1;
                    port = _usersData[e.TelephoneNumber].Item1;
                    }
                if (targetPort.PortState ==PortState.Connected && port.PortState == PortState.Connected)
                {
                   if (e is EventArgsAnswer)
                    {
                        var answerArgs = (EventArgsAnswer)e;

                        if (!answerArgs.Id.Equals(Guid.Empty) && _callList.Any(x => x.Id.Equals(answerArgs.Id)))
                        {
                            inf = _callList.First(x => x.Id.Equals(answerArgs.Id));
                        }

                        if (inf != null)
                        {
                            targetPort.AnswerCall(answerArgs.TelephoneNumber, answerArgs.TargetTelephoneNumber, answerArgs.StateInCall, inf.Id);
                        }
                        else
                        {
                            targetPort.AnswerCall(answerArgs.TelephoneNumber, answerArgs.TargetTelephoneNumber, answerArgs.StateInCall);
                        }
                    }
                    if (e is EventArgsCall)
                    {
                       var callArgs = (EventArgsCall)e;

                            if (callArgs.Id.Equals(Guid.Empty))
                            {
                                inf = new CallInfo(
                                    callArgs.TelephoneNumber,
                                    callArgs.TargetTelephoneNumber,
                                    DateTime.Now,DateTime.Now, DateTime.Now);
                                _callList.Add(inf);
                            }

                            if (!callArgs.Id.Equals(Guid.Empty) && _callList.Any(x => x.Id.Equals(callArgs.Id)))
                            {
                                inf = _callList.First(x => x.Id.Equals(callArgs.Id));
                            }
                            if (inf != null)
                            {
                                targetPort.IncomingCall(callArgs.TelephoneNumber, callArgs.TargetTelephoneNumber, inf.Id);
                            }
                            else
                            {
                                targetPort.IncomingCall(callArgs.TelephoneNumber, callArgs.TargetTelephoneNumber);
                            }
                       }
                    if (e is EventArgsEndCall)
                    {
                        var args = (EventArgsEndCall)e;
                        inf = _callList.First(x => x.Id.Equals(args.Id));
                        inf.TimeEndCall = DateTime.Now;
                        targetPort.AnswerCall(args.TelephoneNumber, args.TargetTelephoneNumber, CallState.Rejected, inf.Id);
                    }
                }
            }
            else if (!_usersData.ContainsKey(e.TargetTelephoneNumber))
            {
                Console.WriteLine("{0} is non-existent number!!!", e.TargetTelephoneNumber);
            }
            else
            {
                Console.WriteLine("{0} is your number!!!", e.TargetTelephoneNumber);
            }
        }
    }


}
