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
  public  class ATE:IATE
    {
        private readonly IDictionary< IPort,ITerminal> _usersData;
        private readonly ICollection<CallInfo> _callList;
        public ATE(IDictionary<IPort, ITerminal> usersData)
        {
            _usersData = usersData;
            _callList = new List<CallInfo>();
        }

        public ATE()
        {
            _usersData = new Dictionary<IPort, ITerminal>();
            _callList = new List<CallInfo>();
        }

        public void CallProcessing(object sender, EventArgsCallToPort e)
        {
        }

        public ICollection<CallInfo> GetInfoList()
        {
            return _callList;
        }

       
        public ITerminal ConnectToPortTerminal(int number)
        {
          var newPort = new Port();
          newPort.CallEvent += CallingTo;
          var newTerminal = new Terminal(number, newPort);
          _usersData.Add(newPort, newTerminal);
          return newTerminal;
        }

        public void CallingTo(object sender, IEventArgsCalling e)
        {
           
        }
    }


}
