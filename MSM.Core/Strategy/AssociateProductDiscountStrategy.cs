using System.Linq;
using MSM.Core.Interfaces;
using MSM.Core.Models;

namespace MSM.Core.Strategy
{
    public class AssociateProductDiscountStrategy : DiscountStrategy, IStrategy
    {
        public AssociateProductDiscountStrategy(int productId, int minQuantity,
            int offerProductId, decimal offerPercentage) : base(productId, minQuantity, offerProductId, offerPercentage)
        {
        }

        public override decimal CalculateDiscount(Basket basket)
        {
            var totalQuantity = basket.BasketItem.Where(x => x.Product.Id == ProductId).Sum(x => x.Quantity);
            var totalOfferProductQuantity = basket.BasketItem.Where(x => x.Product.Id == AssociateProductId).Sum(x => x.Quantity);

            var associateItem = basket.BasketItem.FirstOrDefault(x => x.Product.Id == AssociateProductId);

            if (associateItem == null)
            {
                return 0m;
            }

            return GetDiscount(totalQuantity, totalOfferProductQuantity, associateItem.Product);
        }

        private decimal GetDiscount(int totalQuantity, int offerQuantity, Product associateProduct)
        {
            if (totalQuantity < MinQuantity || offerQuantity == 0)
            {
                return 0m;
            }

            var totalQuantityforDiscount = totalQuantity / MinQuantity;

            var discountPrice = (associateProduct.Price * DiscountPresentage) / 100;

            return totalQuantityforDiscount * discountPrice;
        }
    }
}