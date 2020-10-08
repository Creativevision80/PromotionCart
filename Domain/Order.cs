// Decompiled with JetBrains decompiler
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public int? OrderID { get; set; }

        public List<Product> Products { get; set; }
    }
}
