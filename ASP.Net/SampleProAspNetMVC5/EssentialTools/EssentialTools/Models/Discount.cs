using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTools.Models
{
	public class DiscountHelper : IDiscountHelper
	{
		public decimal DiscountSize { get; set; }
		public decimal ApplyDiscount(decimal total)
		{
			return (total - (DiscountSize/ 100m * total));
		}
	}

	public interface IDiscountHelper
	{
		decimal ApplyDiscount(decimal total);
	}
}
