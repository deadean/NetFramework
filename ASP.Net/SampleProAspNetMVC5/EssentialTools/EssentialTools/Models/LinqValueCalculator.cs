using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTools.Models
{
	public class LinqValueCalculator:IValueCalculator
	{
		private IDiscountHelper modDiscountHelper;
		public LinqValueCalculator(IDiscountHelper helper)
		{
			modDiscountHelper = helper;
		}
		public decimal ValueProducts(IEnumerable<Product> products)
		{
			return modDiscountHelper.ApplyDiscount(products.Sum(x => x.Price));
		}
	}
}
