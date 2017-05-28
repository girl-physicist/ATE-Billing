using ATE.BL.Classes;

namespace ATE.BL.Interfaces
{
    public interface IATE
    {
        void AddUsersData(ITerminal terminal);
        CallInfo GetInfoList();
    }
}
