﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SuccessMarket.Models.DataModels
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
