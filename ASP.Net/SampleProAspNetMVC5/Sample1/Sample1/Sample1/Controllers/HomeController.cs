using Sample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample1.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ViewResult Index()
		{
			int hour = DateTime.Now.Hour;
			ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
			return View();
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse response)
		{
			return View("Thanks", response);
		}


		//public ActionResult Index()
		//{
		//	return View();
		//}

		//public string Index()
		//{
		//	return "Hello world";
		//}
	}
}