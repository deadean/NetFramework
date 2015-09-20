using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.Tests
{
	[TestClass]
	public class UnitTest1:BaseTest
	{
    public UnitTest1()
		{
			
		}

		[TestMethod]
		public void Can_Generate_Page_Links()
		{
			HtmlHelper myHelper = null;
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 4,
				ItemsPerPage = 1
			};

			Func<int, string> pageUrlDelegate = i => "Page" + i;
			MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
			Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
			+@"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
			+@"<a class=""btn btn-default"" href=""Page3"">3</a>"
			, result.ToString());
		}

		[TestMethod]
		public void Can_Send_Pagination_View_Model()
		{
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			ProductsListViewModel vm = 
				(ProductsListViewModel)controller.List(null, 2).Model;
			PagingInfo pageInfo = vm.PagingInfo;
			Assert.AreEqual(pageInfo.CurrentPage, 2);
			Assert.AreEqual(pageInfo.ItemsPerPage, 3);
			Assert.AreEqual(pageInfo.TotalItems, 5);
			Assert.AreEqual(pageInfo.TotalPages, 2);
		}

		[TestMethod]
		public void Can_Filter_Products()
		{
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			ProductsListViewModel vm =
				(ProductsListViewModel)controller.List("Cat2", 1).Model;

			Product[] products = vm.Products.ToArray();

			Assert.AreEqual(products.Length, 2);
			Assert.IsTrue(products[0].Name == "Product2" && products[0].Category == "Cat2");
			Assert.IsTrue(products[1].Name == "Product4" && products[1].Category == "Cat2");
		}

		[TestMethod]
		public void Can_Create_Categories()
		{
			NavController controller = new NavController(mock.Object);

			string[] results = 
				((IEnumerable<string>)controller.Menu().Model).ToArray();

			Assert.AreEqual(results.Length, 3);
			Assert.AreEqual(results[0], "Cat1");
			Assert.AreEqual(results[1], "Cat2");
			Assert.AreEqual(results[2], "Cat3");
		}

		[TestMethod]
		public void Indicates_Selected_Category()
		{
			NavController controller = new NavController(mock.Object);
			string categoryToSelect = "Cat1";

			string result = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;

			Assert.AreEqual(result, categoryToSelect);
		}

		[TestMethod]
		public void Generate_Category_Specififc_Product_Count()
		{
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;
			ProductsListViewModel vm =
				(ProductsListViewModel)controller.List("Cat1").Model;
			ProductsListViewModel vm1 =
				(ProductsListViewModel)controller.List("Cat2").Model;
			ProductsListViewModel vm2 =
				(ProductsListViewModel)controller.List("Cat3").Model;
			ProductsListViewModel vm3 =
				(ProductsListViewModel)controller.List(null).Model;

			Assert.AreEqual(vm.PagingInfo.TotalItems, 2);
			Assert.AreEqual(vm1.PagingInfo.TotalItems, 2);
			Assert.AreEqual(vm2.PagingInfo.TotalItems, 1);
			Assert.AreEqual(vm3.PagingInfo.TotalItems, 5);
		}
	}
}
