using System;
using System.Collections.Generic;

#nullable disable

namespace SuccessMarket.Models.DataModels
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
