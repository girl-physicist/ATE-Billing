using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Interfaces;
using Billing.BL.Enums;
using Billing.BL.Interfaces;

namespace Demo
{
    public class Sorted
    {
        public void ShowSortedCallInfo(IReportRender render, Billing.BL.Classes.Billing billing, ITerminal terminal)
        {
            bool flag = true;
            SortingType sortingType = SortingType.ByCost;
            while (flag)
            {
                Console.WriteLine("Select the sort type:\n " +
                                  "ByDateOfCall (enter {0}),\n " +
                                  "ByCost (enter {1}),\n " +
                                  "ByNumber (enter {2}),\n " +
                                  "ByCallType (enter {3}),\n"
                    , 1, 2, 3, 4);
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
                {
                    flag = false;
                    sortingType = SortingType.ByDateOfCall;
                }
                else if (key == ConsoleKey.NumPad2 || key == ConsoleKey.D2)
                {
                    flag = false;
                    sortingType = SortingType.ByCost;
                }
                else if (key == ConsoleKey.NumPad3 || key == ConsoleKey.D3)
                {
                    flag = false;
                    sortingType = SortingType.BySubscriber;
                }
                else if (key == ConsoleKey.NumPad4 || key == ConsoleKey.D4)
                {
                    flag = false;
                    sortingType = SortingType.ByCallType;
                }
                else
                {
                    Console.WriteLine();
                }
            }

            foreach (var item in render.SortCalls(billing.GetReport(terminal.TelephonNumber), sortingType))
            {
                Console.WriteLine("Calls:\n Type {0} |\n Date: {1} |\n Duration: {2} | Cost: {3} | Telephone number: {4} | Target number: {5}",
                    item.CallType, item.Date, item.Time.ToString("mm:ss"), item.Cost, item.Number, item.TargetNumber);
            }
        }
    }
}
