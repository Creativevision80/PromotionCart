﻿using Application.Errors;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly IPromotionChecker _promotionChecker;

        public CartController(IPromotionChecker promotionChecker)
        {
            
            this._promotionChecker = promotionChecker;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> response = await _promotionChecker.GetProducts();
            if (null == response)
               throw new RestException(HttpStatusCode.NotFound, new
                                                                    {
                                                                        Products = "Not found"
                                                                    });
            return response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<DiscountDto>> CheckOut([FromBody] Order order)
        {
            if (order != null || order.Products.Any())
            {
                if (!order.OrderID.HasValue)
                    throw new Exception("OrderId should be supplied");
                foreach (Product product in order.Products)
                {
                    if(string.IsNullOrEmpty(product.Id))
                        throw new Exception("Product Id should be supplied");
                }
            }
            DiscountDto response = await this._promotionChecker.GetTotalPrice(order);
            if(null == response)
                throw new RestException(HttpStatusCode.NotFound, new 
                                                                    {
                                                                        Products = "Not found"
                                                                    });            
            return response;
        }
    }
}
