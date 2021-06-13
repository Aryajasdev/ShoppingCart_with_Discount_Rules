using MSM.Core.Models;

namespace MSM.Core.Strategy
{
    /// <summary>
    /// Abstract base class for Discount Strategies, rest child classes will inherit this class and must implement calculation with their strategy logic
    /// </summary>
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