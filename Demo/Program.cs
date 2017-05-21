using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ISubscriber subscriber2 = new Subscriber("Vonnegut", "Kurt");
            IContract contract1 = new Contract(subscriber1,TariffType.Tarif1 );
            IContract contract2 = new Contract(subscriber2, TariffType.Tarif2);
            //передача номера телефона для терминала GetNewTerminal(int number==contract1.Number)

        }
    }
}
