using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Helper b = new Helper();
            IATE ate = new ATE.BL.Classes.ATE();
            ISubscriber subscriber1 = new Subscriber("Kesey", "Ken");
            IContract contract1 = new Contract(subscriber1, TariffType.Tarif1);
            IPort port1 = new Port();
            ITerminal terminal1 = new Terminal(contract1.Number, port1);
           
            ISubscriber subscriber2 = new Subscriber("Vonnegut", "Kurt");
            IContract contract2 = new Contract(subscriber2, TariffType.Tarif2);
            IPort port2 = new Port();
            ITerminal terminal2 = new Terminal(contract2.Number, port2);


            ate.ConnectPortToTerminal(terminal1);
            ate.ConnectPortToTerminal(terminal2);
            terminal1.ConnectToPort();
            terminal2.ConnectToPort();

            //проверка соединения (случай, когда вызываемый абонент отвечает на звонок)
            terminal1.Call(terminal2.TelephonNumber);
            Thread.Sleep(2000);
            terminal2.EndCall();
            Console.WriteLine();

            //проверка соединения (попытка дозвониться самому себе)
            terminal1.Call(terminal1.TelephonNumber);
            Thread.Sleep(2000);
            Console.WriteLine();

            //проверка соединения (попытка дозвониться на несуществующий номер)
            terminal1.Call(1234567890);
            Thread.Sleep(2000);
            Console.WriteLine();

            //проверка соединения (случай, когда вызываемый абонент отклоняте звонок)
            terminal2.Call(terminal1.TelephonNumber);
            Console.WriteLine();


            ate.GetInfoList();

            Console.ReadLine();










        }
    }
}
