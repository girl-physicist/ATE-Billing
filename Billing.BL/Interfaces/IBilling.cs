using Billing.BL.Classes;

namespace Billing.BL.Interfaces
{
    public interface IBilling
    {
        Report GetReport(int telephoneNumber);
    }
}
