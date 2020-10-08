// Decompiled with JetBrains decompiler
// Type: Domain.Promotion
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Promotion
    {
        public int PromotionID { get; set; }

        public Dictionary<string, int> ProductInfo { get; set; }

        public Decimal PromoPrice { get; set; }
    }
}
