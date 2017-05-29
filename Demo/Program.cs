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
            Billing.BL.Classes.Billing billing = new Billing.BL.Classes.Billing();
            IReportRender render = new ReportRender();
            Sorted sorted=new Sorted();
            IATE ate = new ATE.BL.Classes.ATE(billing);
            ISubscriber subscriber1 = new Subscriber("Kesey", "Ken");
            IContract contract1 = new Contract(subscriber1, TariffType.Tarif1,DateTime.Now);
            IPort port1 = new Port();
            ITerminal terminal1 = new Terminal(contract1.Number, port1);
            ISubscriber subscriber2 = new Subscriber("Vonnegut", "Kurt");
            IContract contract2 = new Contract(subscriber2, TariffType.Tarif2, DateTime.Now);
            IPort port2 = new Port();
            ITerminal terminal2 = new Terminal(contract2.Number, port2);
            ISubscriber subscriber3 = new Subscriber("Feynman", "Richard");
            IContract contract3 = new Contract(subscriber3, TariffType.Tarif3, DateTime.Now);
            IPort port3 = new Port();
            ITerminal terminal3 = new Terminal(contract3.Number, port3);
            billing.RegisterContract(contract1);
            billing.RegisterContract(contract2);
            billing.RegisterContract(contract3);
            ate.AddUsersData(terminal1);
            ate.AddUsersData(terminal2);
            ate.AddUsersData(terminal3);
            terminal1.ConnectToPort();
            terminal2.ConnectToPort();
            terminal3.ConnectToPort();


            //проверка соединения (случай, когда вызываемый абонент отвечает на звонок)
            Console.WriteLine("------t2 answer t1-------");
            terminal1.Call(terminal2.TelephonNumber);
            Thread.Sleep(2000);
            terminal2.EndCall();
            Console.WriteLine();
            Console.WriteLine("------t1 answer t3-------");
            terminal3.Call(terminal1.TelephonNumber);
            Thread.Sleep(2000);
            terminal3.EndCall();
            Console.WriteLine();
            //проверка соединения (случай, когда вызываемый абонент не отвечает на звонок)
            Console.WriteLine("------t2 reject t3-------");
            terminal3.Call(terminal2.TelephonNumber);
            Console.WriteLine();
            //проверка соединения (попытка дозвониться самому себе)
            Console.WriteLine("------t1 call t1-------");
            terminal1.Call(terminal1.TelephonNumber);
            Console.WriteLine();
            //проверка соединения (попытка дозвониться на несуществующий номер)
            Console.WriteLine("------t1 call 1234-------");
            terminal1.Call(1234);
            Console.WriteLine();
            //проверка соединения (случай, когда вызываемый терминал не подключен к порту)
            Console.WriteLine("------t1 call to disconnect t2-------");
            terminal2.DisconnectFromPort();
            terminal1.Call(terminal2.TelephonNumber);
            Thread.Sleep(2000);
            terminal2.EndCall();
            Console.WriteLine();
            // попытка смены тарифного плана
            Console.WriteLine();
            Console.WriteLine(contract1.ChangeTariff(TariffType.Tarif2)
                ? "Tariff has changed!"
                : "Wait until the end of the month!");
            Console.WriteLine();

            // для проверки возможности изменения тарифа
            Console.WriteLine(contract1.ChangeTariff(TariffType.Tarif3,DateTime.Now.AddMonths(-3).Date)
                ? "Tariff has changed!"
                : "Wait until the end of the month!");
            Console.WriteLine();

            // отчет для абонента 1
            sorted.ShowSortedCallInfo(render, billing, terminal1);

            Console.ReadKey();
        }
    }
}
