using System.Collections.Generic;
using MSM.Core.Models;
using MSM.Core.Strategy;

namespace MSM.Tests
{
    public class TestData
    {
        public static List<DiscountStrategy> GetDiscountStrategies()
        {
            return new List<DiscountStrategy>
            {
                new QuantityDiscountStrategy(2,3,2,100),
                new AssociateProductDiscountStrategy(1,2,3, 50)
            };
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{Id = 1, Name = "Butter", Price = 0.8m},
                new Product{Id = 2, Name = "Milk", Price = 1.15m},
                new Product{Id = 3, Name = "Bread", Price = 1.0m}
            };
        }
    }
}
