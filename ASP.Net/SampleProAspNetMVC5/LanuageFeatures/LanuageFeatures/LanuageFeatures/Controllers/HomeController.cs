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

		public ViewResult AutoProperty()
		{
			Product product = new Product();
			product.Name = "Hello test";
			string productName = product.Name;
			return View("Result", (object)String.Format("Product name {0}", productName));

		}
	}
}