using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class DiscountDto
    {
        public string OrderId { get; set; }
        public string OriginalPrice { get; set; }
        public string TotalPriceAfterDiscount { get; set; }
        public string Rebate { get; set; }
        public DiscountDto(
          string orderId,
          string originalPrice,
          string totalPriceAfterDiscount,
          string rebate)
        {
            this.OrderId = orderId;
            this.OriginalPrice = originalPrice;
            this.TotalPriceAfterDiscount = totalPriceAfterDiscount;
            this.Rebate = rebate;
        }
    }
}
