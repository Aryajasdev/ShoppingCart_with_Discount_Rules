using System.Collections.Generic;
using System.Linq;
using MSM.Core.Interfaces;
using MSM.Core.Models;
using MSM.Core.Strategy;

namespace MSM.Core.Impl
{
    public class DiscountEngine : IDiscountEngine
    {
        public decimal ApplyDiscount(Basket basket, List<DiscountStrategy> discountStrategies)
        {
            decimal discount = 0m;
            var lineItems = basket.BasketItem
                .GroupBy(x => x.Product.Id)
                .Select(i => new
            {
                Id = i.Key,
                Qty = i.Count()
            });
            
            foreach (var item in lineItems)
            {
                var strategy = discountStrategies.SingleOrDefault(x => x.ProductId == item.Id);

                if(strategy != null) discount += strategy.CalculateDiscount(basket);
            }

            return discount;
        }
    }
}
