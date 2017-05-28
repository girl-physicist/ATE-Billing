using System;
using ATE.BL.Enums;

namespace ATE.BL.Classes
{
    public class Helper
    {
        public string GetAnswer(int numb, int target)
        {
            string answer = null;
            bool flag = true;
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", numb, target);
            while (flag)
            {
                Console.WriteLine("Answer? Y/N");
                var k = Console.ReadKey().Key;
                switch (k)
                {
                    case ConsoleKey.Y:
                        flag = false;
                        answer = "Answer";
                        Console.WriteLine();
                        break;
                    case ConsoleKey.N:
                        flag = false;
                        answer = "Reject";
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            return answer;
        }
        public void GetMessageAboutNonexistentNumber(int targetTelephoneNumber)
        {
            Console.WriteLine("{0} is non-existent number!!!", targetTelephoneNumber);
        }
        public void GetMessageAboutCallYourself(int targetTelephoneNumber)
        {
            Console.WriteLine("{0} is your number!!!", targetTelephoneNumber);
        }
        public void GetMessageAboutAnswer(CallState stateInCall, int number, int target)
        {
            switch (stateInCall)
            {
                case CallState.Answered:
                    Console.WriteLine("Terminal with number: {0}, have answer on call from number: {1}", number, target);
                    break;
                default:
                    Console.WriteLine("Terminal with number: {0}, have rejected call", number);
                    break;
            }
        }
        public void GetMessageAboutCallToDisconnectTerminal(int targetTelephoneNumber)
        {
            Console.WriteLine(" The phone {0} is not connected to the network!!!", targetTelephoneNumber);
        }
    }
}

