using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository modProductRepository;

		public ProductController(IProductRepository productRepo)
		{
			modProductRepository = productRepo;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ViewResult List()
		{
			var products = modProductRepository.Products.ToList();
      return View(products);
		}
	}
}