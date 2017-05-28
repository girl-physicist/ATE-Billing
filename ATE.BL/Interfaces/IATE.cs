using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Classes;
using ATE.BL.EventArgsHeirs;

namespace ATE.BL.Interfaces
{
   public interface IATE
   {
       void ConnectPortToTerminal(ITerminal terminal);
       //CallInfo GetInfoList();
      ICollection<CallInfo> GetInfoList();
       
    }
}
