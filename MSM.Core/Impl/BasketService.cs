using System.Collections.Generic;
using System.Linq;
using MSM.Core.Interfaces;
using MSM.Core.Models;
using MSM.Core.Strategy;

namespace MSM.Core.Impl
{
    public class BasketService : IBasketService
    {
        private readonly IProductService productService;
        private readonly IDiscountEngine discountService;
        private readonly List<DiscountStrategy> discountStrategies;
        public BasketService(IProductService productService, 
            IDiscountEngine discountService,
            List<DiscountStrategy> discountStrategies)
        {
            this.productService = productService;
            this.discountService = discountService;
            this.discountStrategies = discountStrategies;
        }

        public decimal GetTotal(Basket basket)
        {
            if (basket == null) return 0;
            
            var discount = discountService.ApplyDiscount(basket, discountStrategies);
            var total = basket.BasketItem.Sum(x => x.Quantity * x.Product.Price);
            return total - discount;
        }
    }
}
