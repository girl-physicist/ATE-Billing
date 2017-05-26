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
        //Terminal GetNewTerminal(int number);
        void CallProcessing(object sender, EventArgsCallToPort e);

       ITerminal ConnectToPortTerminal(int number);
    }
}
