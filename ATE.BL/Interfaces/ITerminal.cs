namespace ATE.BL.Interfaces
{
    public interface ITerminal
    {
        int TelephonNumber { get; }
        IPort Port { get; }
        void Call(int targetNumber);
        void ConnectToPort();
        void DisconnectFromPort();
        void EndCall();
    }
}
