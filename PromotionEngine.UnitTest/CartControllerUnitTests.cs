using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionEngine.Controllers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace PromotionEngine.UnitTests
{
    [TestClass]
    public class CartControllerUnitTest
    {
        private Order order = null;
        private List<Product> products = null;
        private DiscountDto discountDto = null;

        public CartControllerUnitTest()
        {
            products = new List<Product>()
                                      {
                                        new Product() { Id = "A", Price = 50M }
                                      };
            order = new Order()
            {
                OrderID = new int?(1),
                Products = products
            };
            discountDto = new DiscountDto("1", "50", "50", "0");
        }

        [Fact]
        public async void OrderIDNullTest()
        {
            try
            {
                Mock<IPromotionChecker> mockRepo = new Mock<IPromotionChecker>();
                CartController cartController = new CartController(mockRepo.Object);
                order.OrderID = null;
                var response = await cartController.CheckOut(order);
            }
            catch (Exception ex)
            {
                Xunit.Assert.Equal("OrderId should be supplied", ex.Message);
            }
        }

        [Fact]
        public async void ProductIDNullTest()
        {
            try
            {
                Mock<IPromotionChecker> mockRepo = new Mock<IPromotionChecker>();
                CartController cartController = new CartController(mockRepo.Object);
                order.Products[0].Id = null;
                var response = await cartController.CheckOut(order);
            }
            catch (Exception ex)
            {
                Xunit.Assert.Equal("Product Id should be supplied", ex.Message);
            }
        }

        [Fact]
        public async void CheckOutCalled()
        {
            Mock<IPromotionChecker> mockRepo = new Mock<IPromotionChecker>();
            mockRepo.Setup(x => x.GetTotalPrice(order)).Returns(Task.FromResult(discountDto));
            CartController cartController = new CartController(mockRepo.Object);
            ActionResult<DiscountDto> discount = await cartController.CheckOut(order);
            Xunit.Assert.Equal("1", discount.Value.OrderId);
            Xunit.Assert.Equal("50", discount.Value.OriginalPrice);
            Xunit.Assert.Equal("50", discount.Value.TotalPriceAfterDiscount);
            Xunit.Assert.Equal("0", discount.Value.Rebate);
        }
    }
}
