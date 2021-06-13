using MSM.Core.Models;

namespace MSM.Core.Strategy
{
    public abstract class DiscountStrategy
    {
        public int ProductId { get; set; }

        public int MinQuantity { get; set; }

        public int AssociateProductId { get; set; }

        public decimal DiscountPresentage { get; set; }

        public DiscountStrategy(int productId, int minQuantity, int associateProductId, decimal discountPresentage)
        {
            ProductId = productId;
            MinQuantity = minQuantity;
            AssociateProductId = associateProductId;
            DiscountPresentage = discountPresentage;
        }

        public abstract decimal CalculateDiscount(Basket basket);
    }
}