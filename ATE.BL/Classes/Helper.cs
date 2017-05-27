using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.BL.Classes
{
  public class Helper
    {
        public string GetAnswer(int numb,int target)
        {
         string answer =null;
            bool flag = true;
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}",numb, target);
            while (flag == true)
            {
                Console.WriteLine("Answer? Y/N");
                var k = Console.ReadKey().Key;
                if (k == ConsoleKey.Y)
                {
                    flag = false;
                    answer = "Answer";
                    Console.WriteLine();
                }
                else if (k == ConsoleKey.N)
                {
                    flag = false;
                    answer = "Reject";
                    Console.WriteLine();
                 }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
              }
            return answer;
        }
    }
}

