using MSM.Core.Models;

namespace MSM.Core.Interfaces
{
    public interface IStrategy
    {
        decimal CalculateDiscount(Basket basket);
    }
}
