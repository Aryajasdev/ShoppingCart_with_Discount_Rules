using System.Collections.Generic;
using MSM.Core.Models;
using MSM.Core.Strategy;

namespace MSM.Core.Interfaces
{
    /// <summary>
    /// Discount Engine to apply discount on basket with various strategies plugged in for basket 
    /// </summary>
    public interface IDiscountEngine
    {
        decimal ApplyDiscount(Basket basket, List<DiscountStrategy> discountStrategies);
    }
}
