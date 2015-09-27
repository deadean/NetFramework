using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using Moq;

namespace SportsStore.Tests
{
	[TestClass]
	public class CartTests:BaseTest
	{
		public CartTests()
		{
		}

		[TestMethod]
		public void Can_Add_New_Lines()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			Assert.AreEqual(target.Lines.Count(), 1);
			Assert.AreEqual(target.Lines.First().Product, mock.Object.Products.First());
		}

		[TestMethod]
		public void Can_Remove_Lines()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			target.RemoveLine(mock.Object.Products.First());

			Assert.AreEqual(target.Lines.Count(), 0);
		}

		[TestMethod]
		public void Can_Calculate_Lines_Total()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			Assert.AreEqual(target.ComputeTotalValue(), 300M);
		}

		[TestMethod]
		public void Can_Clear_Lines_Cart()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			target.Clear();

			Assert.AreEqual(target.Lines.Count(), 0);
		}

		[TestMethod]
		public void Can_Add_To_Cart()
		{
			Cart cart = new Cart();
			CartController target = new CartController(mock.Object, null);

			target.AddToCart(cart, 1, null);

			Assert.AreEqual(cart.Lines.Count(), 1);
			Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
		}

		[TestMethod]
		public void Adding_Cart_Goes_To_Product_Screen()
		{
			Cart cart = new Cart();
			CartController target = new CartController(mock.Object, null);

			RedirectToRouteResult redirect = target.AddToCart(cart, 2, "myUrl");

			Assert.AreEqual(redirect.RouteValues["action"], "Index");
			Assert.AreEqual(redirect.RouteValues["returnUrl"], "myUrl");
		}

		[TestMethod]
		public void Can_View_Cart_Contents()
		{
			Cart cart = new Cart();
			CartController target = new CartController(null, null);

			CartIndexViewModel vm = 
				(CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

			Assert.AreEqual(vm.Cart, cart);
			Assert.AreEqual(vm.ReturnUrl, "myUrl");
		}

		[TestMethod]
		public void Cannot_Checkout_Empty_Cart()
		{
			Cart cart = new Cart();
			ShippingDetails shippingDetails = new ShippingDetails();
			CartController controller = new CartController(null, mockOrderProcessor.Object);
			ViewResult result = controller.Checkout(cart, shippingDetails);

			mockOrderProcessor
				.Verify(m => m
					.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>())
				, Times.Never());
			Assert.AreEqual("", result.ViewName);
			Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
		}

		[TestMethod]
		public void Cannot_Checkout_Invalid_Shipping_Details()
		{
			Cart cart = new Cart();
			cart.AddItem(new Product(), 1);
			CartController target = new CartController(null, mockOrderProcessor.Object);
			target.ModelState.AddModelError("error", "error");
			ViewResult result = target.Checkout(cart, new ShippingDetails());
			mockOrderProcessor
				.Verify(m=>m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
					Times.Never);

			Assert.AreEqual(null, result.View);
			Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
		}

		[TestMethod]
		public void Can_Checkout_And_Submit_Order()
		{
			Cart cart = new Cart();
			cart.AddItem(new Product(), 1);
			CartController target = new CartController(null, mockOrderProcessor.Object);
			ViewResult result = target.Checkout(cart, new ShippingDetails() { City = "1", Country = "1", Line1 = "1", Name = "1", State = "1", GiftWrap = true, Zip = "1"});
			mockOrderProcessor
				.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
					Times.Once);

			Assert.AreEqual("Completed", result.ViewName);
			Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
		}

	}
}
