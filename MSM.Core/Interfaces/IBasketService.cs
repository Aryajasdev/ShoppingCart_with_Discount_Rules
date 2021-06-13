using System;
using System.Collections.Generic;
using System.Text;
using MSM.Core.Models;

namespace MSM.Core.Interfaces
{
    public interface IBasketService
    {
        public decimal GetTotal(Basket basket);
    }
}
