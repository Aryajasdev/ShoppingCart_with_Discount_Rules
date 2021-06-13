using System;
using System.Collections.Generic;
using System.Text;
using MSM.Core.Models;

namespace MSM.Core.Interfaces
{
    /// <summary>
    /// Product Interface to get products
    /// </summary>
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProduct(int Id);
    }
}
