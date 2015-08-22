using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTools.Models
{
	public class ShoppingCart
	{
		private IValueCalculator modCalc;

		public ShoppingCart(IValueCalculator calc)
		{
			modCalc = calc;
		}

		public IEnumerable<Product> Products { get; set; }

		public decimal CalculateProductTotal()
		{
			return modCalc.ValueProducts(Products);
		}
	}
}
