using System.Collections.Generic;
using MSM.Core.Impl;
using MSM.Core.Interfaces;
using MSM.Core.Models;
using NUnit.Framework;

namespace MSM.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IProductService productService;

        [SetUp]
        public void Setup()
        {
            var products = TestData.GetProducts();
            productService = new ProductService(products);
        }

        [Test]
        public void get_product_should_get_single_product()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };

            var result = productService.GetProduct(1);

            Assert.AreEqual(result.Id, product.Id);
            Assert.AreEqual(result.Price, product.Price);
            Assert.AreEqual(result.Name, product.Name);
        }

        [Test]
        public void get_products_should_get_all_product()
        {
            var result = productService.GetProducts();

            Assert.AreEqual(3, result.Count);
        }
    }
}