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
		// GET: Home
		public string Index()
		{
			return "Navigate to URL to Show an example";
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