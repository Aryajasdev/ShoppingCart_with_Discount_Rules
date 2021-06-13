using System;
using System.Collections.Generic;
using MSM.Core.Models;
using MSM.Core.Strategy;
using NUnit.Framework;

namespace MSM.Tests
{
    [TestFixture]
    public class StrategyTests
    {
        private DiscountStrategy _strategy;

        [Test]
        public void Quantity_Discount_Strategy_should_return_1_Product_Free()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    }
                }
            };

            _strategy = new QuantityDiscountStrategy(2, 4, 2, 100);

            var result= _strategy.CalculateDiscount(basket);

            Assert.AreEqual(1.15m, result);
        }

        [Test]
        public void Quantity_Discount_Strategy_should_return_1_Product_Free_If_Basket_Has_Plus_one_Product_Then_Offer()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    }
                }
            };

            _strategy = new QuantityDiscountStrategy(2, 4, 2, 100);

            var result = _strategy.CalculateDiscount(basket);

            Assert.AreEqual(1.15m, result);
        }

        [Test]
        public void Associate_Product_Discount_Strategy_should_return_Half_Bread_Price_As_Discount()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            _strategy = new AssociateProductDiscountStrategy(1, 2, 3, 50);

            var result = _strategy.CalculateDiscount(basket);

            Assert.AreEqual(0.5m, result);
        }

        [Test]
        public void Associate_Product_Discount_Strategy_should_return_Bread_Price_As_Discount()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            _strategy = new AssociateProductDiscountStrategy(1, 2, 3, 50);

            var result = _strategy.CalculateDiscount(basket);

            Assert.AreEqual(1m, result);
        }
    }
}