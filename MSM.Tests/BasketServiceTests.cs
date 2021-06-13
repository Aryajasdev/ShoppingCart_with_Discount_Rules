using System;
using System.Collections.Generic;
using Moq;
using MSM.Core.Impl;
using MSM.Core.Interfaces;
using MSM.Core.Models;
using MSM.Core.Strategy;
using NUnit.Framework;

namespace MSM.Tests
{
    [TestFixture]
    public class BasketServiceTests
    {
        private Mock<IProductService> productService;
        private Mock<IDiscountEngine> discountEngine;
        private IBasketService basketService;

        [SetUp]
        public void Setup()
        {
            productService = new Mock<IProductService>();
            discountEngine = new Mock<IDiscountEngine>();
            var discountStrategies = TestData.GetDiscountStrategies();
            basketService = new BasketService(productService.Object, discountEngine.Object, discountStrategies);
        }

        [Test]
        public void Given_the_basket_has_1_bread_1_butter_and_1_milk_then_total_should_295()
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
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            discountEngine.Setup(x => x.ApplyDiscount(It.IsAny<Basket>(), It.IsAny<List<DiscountStrategy>>())).Returns(0m);

            var result = basketService.GetTotal(basket);

            Assert.AreEqual(result, 2.95m);
        }

        [Test]
        public void Given_the_basket_has_2_bread_2_butter_then_total_should_310()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 2
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 2
                    }
                }
            };

            discountEngine.Setup(x => x.ApplyDiscount(It.IsAny<Basket>(), It.IsAny<List<DiscountStrategy>>())).Returns(0.5m);

            var result = basketService.GetTotal(basket);

            Assert.AreEqual(result, 3.10m);
        }

        [Test]
        public void Given_the_basket_has_4_Milk_then_total_should_345()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 4
                    }
                }
            };

            discountEngine.Setup(x => x.ApplyDiscount(It.IsAny<Basket>(), It.IsAny<List<DiscountStrategy>>())).Returns(1.15m);

            var result = basketService.GetTotal(basket);

            Assert.AreEqual(result, 3.45m);
        }

        [Test]
        public void Given_the_basket_has_2_butter_1_bread_and_8_milk_then_total_should_9()
        {
            var basket = new Basket
            {
                Id = new Guid(),
                BasketItem = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product {Id = 1, Name = "Butter", Price = 0.8m}, Quantity = 2
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 2, Name = "Milk", Price = 1.15m}, Quantity = 8
                    },
                    new BasketItem
                    {
                        Product = new Product {Id = 3, Name = "Bread", Price = 1m}, Quantity = 1
                    }
                }
            };

            discountEngine.Setup(x => x.ApplyDiscount(It.IsAny<Basket>(), It.IsAny<List<DiscountStrategy>>())).Returns(2.80m);

            var result = basketService.GetTotal(basket);

            Assert.AreEqual(result, 9m);
        }
    }
}