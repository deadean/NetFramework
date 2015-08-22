using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
	public class HomeController : Controller
	{
		private Product[] modProduct =
		{
			new Product() { Name = "Kayak", Category = "WaterSports", Price = 275M },
			new Product() { Name = "LifeJacket", Category = "WaterSports", Price = 48.9M },
			new Product() { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
			new Product() { Name = "Corner flag", Category = "Soccer", Price = 34.95M },
		};

		private IValueCalculator modCalc;

		public HomeController(IValueCalculator calc)
		{
			modCalc = calc;
		}

		// GET: Home
		public ActionResult Index()
		{
			ShoppingCart cart = new ShoppingCart(modCalc) { Products = modProduct };

			decimal total = cart.CalculateProductTotal();
			return View(total);
		}
	}
}