using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
	public class NavController : Controller
	{
		private readonly IProductRepository modRepository;

		public NavController(IProductRepository repo)
		{
			modRepository = repo;
		}

		public PartialViewResult Menu(string category = null)
		{
			ViewBag.SelectedCategory = category;
			IEnumerable<string> categories = modRepository.Products
													.Select(x => x.Category)
													.Distinct()
													.OrderBy(x => x);

			return PartialView(categories);
		}

	}
}