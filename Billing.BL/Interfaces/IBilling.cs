using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.BL.Classes;

namespace Billing.BL.Interfaces
{
  public  interface IBilling
    {
        Report GetReport(int telephoneNumber);
    }
}
