using System;
using System.Collections.Generic;
using MSM.Core.Impl;
using MSM.Core.Interfaces;
using MSM.Core.Models;
using NUnit.Framework;

namespace MSM.Tests
{
    [TestFixture]
    public class DiscountEngineTests
    {

        private IDiscountEngine discountEngine;

        [SetUp]
        public void Setup()
        {
            discountEngine = new DiscountEngine();
        }

        [Test]
        public void Discount_Engine_Should_Return_0_Discount()
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
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            var result = discountEngine.ApplyDiscount(basket, TestData.GetDiscountStrategies());

            Assert.AreEqual(result, 0m);

        }

        [Test]
        public void Discount_Service_Should_Return_Discount_Half_Bread_Price_As_Discount()
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
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            var result = discountEngine.ApplyDiscount(basket, TestData.GetDiscountStrategies());

            Assert.AreEqual(result, 0.5m);
        }

        [Test]
        public void Discount_Service_Should_Return_Discount_Half_Bread_Price_As_Discount_IF_3_Bread_in_Basket()
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
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 1
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            var result = discountEngine.ApplyDiscount(basket, TestData.GetDiscountStrategies());

            Assert.AreEqual(result, 0.5m);
        }

        [Test]
        public void Discount_Service_Should_Return_1_Milk_Price_As_Discount()
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
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    },new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 1
                    }
                }
            };

            var result = discountEngine.ApplyDiscount(basket, TestData.GetDiscountStrategies());

            Assert.AreEqual(result, 1.15m);
        }
    }
}