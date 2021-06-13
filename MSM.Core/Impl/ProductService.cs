using System;
using System.Collections.Generic;
using System.Linq;
using MSM.Core.Interfaces;
using MSM.Core.Models;

namespace MSM.Core.Impl
{
    /// <summary>
    /// Concrete implamentation of product service
    /// </summary>
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; }

        public ProductService(List<Product> products)
        {
            this.Products = products;
        }

        public Product GetProduct(int Id)
        {
            return Products.Single(x => x.Id == Id);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        
    }
}
