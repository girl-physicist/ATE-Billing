using System.Threading;
using ATE.BL.Interfaces;

namespace Demo
{
    public class Helper
    {
        public void CheckCompletionOfCall(ITerminal callerTerminal, ITerminal targetTerminal, string stateAnswer)
        {
           if (callerTerminal.TelephonNumber == targetTerminal.TelephonNumber)
            {
                //занести время окончания звонка
            }
            else if (stateAnswer=="Reject")
            {
               //занести время окончания звонка
            }
            else
            {
                Thread.Sleep(2000);
                targetTerminal.EndCall();
            }

        }
    }
}
