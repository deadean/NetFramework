using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
	public class CartController : Controller
	{

		#region Fields

		private readonly IProductRepository modProductRepository;
		private readonly IOrderProcessor modOrderProcessor;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public CartController(IProductRepository repo, IOrderProcessor orderProcessor)
		{
			modProductRepository = repo;
			modOrderProcessor = orderProcessor;
		}

		#endregion

		#region Public Methods

		[HttpPost]
		public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
		{
			if(cart.Lines.Count() == 0)
			{
				ModelState.AddModelError("", "Sorry, your cart is empty");
			}
			if (ModelState.IsValid)
			{
				modOrderProcessor.ProcessOrder(cart, shippingDetails);
				cart.Clear();
				return View("Completed");
			}
			else
			{
				return View(shippingDetails);
			}
		}

		public ViewResult Checkout()
		{
			return View(new ShippingDetails());
		}

		public PartialViewResult Summary(Cart cart)
		{
			return PartialView(cart);
		}

		public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
		{
			Product product = modProductRepository.Products
							.FirstOrDefault(x => x.ProductID == productId);

			if(product!=null)
			{
				cart.AddItem(product, 1);
			}

			return RedirectToAction("Index", new { returnUrl = returnUrl});
		}

		public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
		{
			Product product = modProductRepository.Products
							.FirstOrDefault(x => x.ProductID == productId);
			if (product != null)
			{
				cart.RemoveLine(product);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

		public ViewResult Index(Cart cart, string returnUrl)
		{
			return View(new CartIndexViewModel
				{ Cart = cart, ReturnUrl = returnUrl});
		}

		#endregion

		#region Private Methods

		private Cart GetCart()
		{
			Cart cart = Session["Cart"] as Cart;
			if(cart == null)
			{
				cart = new Cart();
				Session["Cart"] = cart;
			}

			return cart;
		}

		#endregion

		#region Protected Methods

		#endregion
	}
}