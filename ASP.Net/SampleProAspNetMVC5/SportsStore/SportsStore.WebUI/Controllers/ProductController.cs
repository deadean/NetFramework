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

		#region Fields

		private IProductRepository modProductRepository;

		#endregion

		#region Properties

		public int PageSize { get; set; }

		#endregion

		#region Ctor

		public ProductController(IProductRepository productRepo)
		{
			modProductRepository = productRepo;
			PageSize = 4;
		}

		#endregion

		#region Public Methods

		public ActionResult Index()
		{
			return View();
		}

		public ViewResult List(string category, int page = 1)
		{
			var products = modProductRepository.Products.ToList();
			products = String.IsNullOrWhiteSpace(category)
				? products
        : products.Where(x => x.Category == null || x.Category == category).ToList();

			ProductsListViewModel vm = new ProductsListViewModel
			{
				Products = products.OrderBy(x => x.ProductID)
														.Skip((page - 1) * PageSize)
														.Take(PageSize),
				PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = products.Count() },
				CurrentCategory = category
			};

			return View(vm);
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

	}
}