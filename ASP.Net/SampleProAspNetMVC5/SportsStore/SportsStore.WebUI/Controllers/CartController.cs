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

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public CartController(IProductRepository repo)
		{
			modProductRepository = repo;
		}

		#endregion

		#region Public Methods

		public RedirectToRouteResult AddToCart(int productId, string returnUrl)
		{
			Product product = modProductRepository.Products
							.FirstOrDefault(x => x.ProductID == productId);

			if(product!=null)
			{
				this.GetCart().AddItem(product, 1);
			}

			return RedirectToAction("Index", new { returnUrl = returnUrl});
		}

		public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
		{
			Product product = modProductRepository.Products
							.FirstOrDefault(x => x.ProductID == productId);
			if (product != null)
			{
				this.GetCart().RemoveLine(product);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

		public ViewResult Index(string returnUrl)
		{
			return View(new CartIndexViewModel
				{ Cart = this.GetCart(), ReturnUrl = returnUrl});
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