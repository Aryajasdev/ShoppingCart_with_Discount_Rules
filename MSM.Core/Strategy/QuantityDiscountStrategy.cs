using System.Linq;
using MSM.Core.Models;

namespace MSM.Core.Strategy
{
    /// <summary>
    /// Derived class of Base DiscountStrategy to implement Quantity based discount logic
    /// </summary>
    public class QuantityDiscountStrategy : DiscountStrategy
    {
        public QuantityDiscountStrategy(int productId, int minQuantity, int offerProductId, decimal offerPercentage) : base(productId, minQuantity, offerProductId, offerPercentage)
        {
        }

        public override decimal CalculateDiscount(Basket basket)
        {
            var offerItem = basket.BasketItem.FirstOrDefault(x => x.Product.Id == AssociateProductId);
            if (offerItem == null) return 0m;

            var totalQuantity = basket.BasketItem.Where(x => x.Product.Id == ProductId).Sum(x => x.Quantity);
            return GetDiscount(totalQuantity, offerItem.Product);
        }

        private decimal GetDiscount(int totalQuantity, Product offerProduct)
        {
            if (totalQuantity < MinQuantity)
            {
                return 0m;
            }

            var discountPrice = (offerProduct.Price * DiscountPresentage) / 100;

            var totalQuantityforDiscount = totalQuantity / MinQuantity;

            return totalQuantityforDiscount * discountPrice;
        }
    }
}