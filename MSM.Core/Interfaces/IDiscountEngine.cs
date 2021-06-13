using System.Collections.Generic;
using MSM.Core.Models;
using MSM.Core.Strategy;

namespace MSM.Core.Interfaces
{
    public interface IDiscountEngine
    {
        decimal ApplyDiscount(Basket basket, List<DiscountStrategy> discountStrategies);
    }
}
