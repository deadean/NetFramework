using LanuageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanuageFeatures.Controllers
{
	public class HomeController : Controller
	{

		private Product modProduct = new Product()
		{
			ProductID = 1,
			Description = "A boat for one person",
			Name = "Kayak",
			Price = 275M,
			Category = "Watersports"
		};
		// GET: Home
		public ActionResult Index()
		{
			return View(modProduct);
		}

		public ActionResult NameAndPrice()
		{
			return View(modProduct);
		}

		public ActionResult DemoExpression()
		{
			ViewBag.ProductCount = 1;
			ViewBag.ExpressShip = true;
			ViewBag.ApplyDiscount = false;
			ViewBag.Supplier = null;

			return View(modProduct);
		}

		public ActionResult DemoArray()
		{
			Product[] array =
			{
				new Product { Name="Kayak", Price=275M},
				new Product { Name="Lifejacket", Price=48.95M},
				new Product { Name="Soccer ball", Price=19.50M},
				new Product { Name="Corner flag", Price=34.95M}
			};

			return View(array);
		}

		public ViewResult AutoProperty()
		{
			Product product = new Product();
			product.Name = "Hello test";
			string productName = product.Name;
			return View("Result", (object)String.Format("Product name {0}", productName));

		}
	}
}