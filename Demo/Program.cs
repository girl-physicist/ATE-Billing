using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.BL.Interfaces;
using ATE.BL.Classes;
using ATE.BL.EventArgsHeirs;
using Billing.BL.Classes;
using Billing.BL.Enums;
using Billing.BL.Interfaces;



namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper b=new Helper();
            //b.Num();
            IATE ate1=new ATE.BL.Classes.ATE();
            ISubscriber subscriber1 = new Subscriber("Kesey", "Ken");
            IContract contract1 = new Contract(subscriber1, TariffType.Tarif1);
            IPort port1=new Port();
            ITerminal terminal1=new Terminal(contract1.Number,port1);



            IATE ate2 = new ATE.BL.Classes.ATE();
            ISubscriber subscriber2 = new Subscriber("Vonnegut", "Kurt");
            IContract contract2 = new Contract(subscriber2, TariffType.Tarif2);
            IPort port2 = new Port();
            ITerminal terminal2 = new Terminal(contract2.Number, port2);

           
            ate1.ConnectToPortTerminal(terminal1.TelephonNumber);
            terminal1.ConnectToPort();
            terminal1.Call(terminal2.TelephonNumber);
            Console.ReadLine();
        }
    }
}
