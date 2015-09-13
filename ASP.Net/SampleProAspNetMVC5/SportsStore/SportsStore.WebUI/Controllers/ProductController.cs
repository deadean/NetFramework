using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
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
			PageSize = 4;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ViewResult List(int page = 1)
		{
			var products = modProductRepository.Products.ToList();
			ProductsListViewModel vm = new ProductsListViewModel
			{
				Products = products.OrderBy(x => x.ProductID)
														.Skip((page - 1) * PageSize)
														.Take(PageSize),
				PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = products.Count }
			};
			
      return View(vm);
		}

		public int PageSize { get; set; }
	}
}