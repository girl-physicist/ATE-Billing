using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Interfaces;
using ATE.BL.Classes;
using Billing.BL.Classes;
using Billing.BL.Enums;
using Billing.BL.Interfaces;


namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ISubscriber subscriber1 = new Subscriber("Kesey", "Ken");
            IContract contract1 = new Contract(subscriber1, TariffType.Tarif1);
            IATE ate1 = new ATE.BL.Classes.ATE();
            ate1.GetNewTerminal(contract1.Number);

            ISubscriber subscriber2 = new Subscriber("Vonnegut", "Kurt");
            IContract contract2 = new Contract(subscriber2, TariffType.Tarif2);
            IATE ate2 = new ATE.BL.Classes.ATE();
            ate2.GetNewTerminal(contract2.Number);
            //передача номера телефона для терминала GetNewTerminal(int number==contract1.Number)
            Console.ReadLine();
        }
    }
}
