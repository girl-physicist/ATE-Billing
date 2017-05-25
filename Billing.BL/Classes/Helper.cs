using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.BL.Classes
{
  public  class Helper
    {
        public static int[] GenerateNumber()
        {
            int[] number = new int[900000];
            for (int i = 100000; i <= 999999; i++)
            {
                 number[i-100000] = i ; 
            }
            return number;
        }

        public int Num()
        {
          return GenerateNumber().ElementAt(0); 
        }
       
    }
}
