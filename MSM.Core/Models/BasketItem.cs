using System;

namespace MSM.Core.Models
{
    /// <summary>
    /// Basket Item with Product and Quantity
    /// </summary>
    public class BasketItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}