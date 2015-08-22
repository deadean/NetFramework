using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTools.Models
{
	public class FlexibleDiscountHelper : IDiscountHelper
	{
		public decimal ApplyDiscount(decimal total)
		{
			decimal disount = total > 100 ? 70 : 25;
			return (total - (disount / 10m * total));
		}
	}
}
