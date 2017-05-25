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
        //  private readonly ICollection<CallInformation> _callList = new List<CallInformation>();
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
           
            //var targetPort = _usersData.Where(x => x.Value.TelephonNumber == e.TargetTelephoneNumber).Select(x => x.Key)
            //    .ElementAt(0);
            //if (targetPort.PortState == PortState.Connected)
            //{

            //}
            //else
            //{

            //}
        }

        public ICollection<CallInfo> GetInfoList()
        {
            return _callList;
        }

        
    }


}
