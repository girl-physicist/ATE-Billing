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
        private readonly IDictionary<int, Port> _usersData;
        private readonly ICollection<CallInfo> _callList;
        //  private readonly ICollection<CallInformation> _callList = new List<CallInformation>();
        public ATE(IDictionary<int, Port> usersData, ICollection<CallInfo> callList)
        {
            _usersData = usersData;
            _callList = callList;
        }

        public ATE()
        {
            _usersData = new Dictionary<int, Port>();
        }

        public Terminal GetNewTerminal(int number)
        {
          
            var newPort = new Port();
            // сделать подписку на события
           
            _usersData.Add(number, newPort);
            var newTerminal = new Terminal(number, newPort);
            return newTerminal;
        }

        public ICollection<CallInfo> GetInfoList()
        {
            return _callList;
        }

    }

    
}
