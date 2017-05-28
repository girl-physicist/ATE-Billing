﻿using System;
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
            IContract contract1 = new Contract(subscriber1, TariffType.Tarif1);
            billing.RegisterContract(contract1);
            IPort port1 = new Port();
            ITerminal terminal1 = new Terminal(contract1.Number, port1);
           
            ISubscriber subscriber2 = new Subscriber("Vonnegut", "Kurt");
            IContract contract2 = new Contract(subscriber2, TariffType.Tarif2);
            billing.RegisterContract(contract2);
            IPort port2 = new Port();
            ITerminal terminal2 = new Terminal(contract2.Number, port2);

            ISubscriber subscriber3 = new Subscriber("Kesey", "Ken");
            IContract contract3 = new Contract(subscriber3, TariffType.Tarif3);
            billing.RegisterContract(contract3);
            IPort port3 = new Port();
            ITerminal terminal3 = new Terminal(contract3.Number, port3);

            ate.AddUsersData(terminal1);
            ate.AddUsersData(terminal2);
            ate.AddUsersData(terminal3);
            terminal1.ConnectToPort();
            terminal2.ConnectToPort();
            terminal3.ConnectToPort();


            //проверка соединения (случай, когда вызываемый абонент отвечает на звонок)
            terminal1.Call(terminal2.TelephonNumber);
            Thread.Sleep(2000);
            terminal2.EndCall();
            Console.WriteLine();

            terminal1.Call(terminal3.TelephonNumber);
            Thread.Sleep(2000);
            terminal3.EndCall();
            Console.WriteLine();

            terminal3.Call(terminal2.TelephonNumber);
            Thread.Sleep(2000);
            terminal2.EndCall();
            Console.WriteLine();

            terminal3.Call(terminal1.TelephonNumber);
            Thread.Sleep(2000);
            terminal1.EndCall();
            Console.WriteLine();

            //проверка соединения (попытка дозвониться самому себе)
            terminal1.Call(terminal1.TelephonNumber);
            Thread.Sleep(2000);
            Console.WriteLine();

            //проверка соединения (попытка дозвониться на несуществующий номер)
            terminal1.Call(1234567890);
            Thread.Sleep(2000);
            Console.WriteLine();

            //проверка соединения (случай, когда вызываемый абонент не отвечает на звонок)
            terminal2.Call(terminal1.TelephonNumber);
            //terminal1.EndCall();
            Console.WriteLine();

            //проверка соединения (случай, когда вызываемый терминал не подключен к порту)
            terminal2.DisconnectFromPort();
            terminal1.Call(terminal2.TelephonNumber);
            Thread.Sleep(2000);
            terminal2.EndCall();
            Console.WriteLine();

           
           // Console.WriteLine("Select for which subscriber to show the information");
            sorted.ShowSortedCallInfo(render, billing, terminal1);



            Console.ReadKey();








        }
    }
}
