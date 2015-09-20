using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
	public class Cart
	{

		#region Fields

		private List<CartLine> modLineCollection = new List<CartLine>();

		#endregion

		#region Properties

		public IEnumerable<CartLine> Lines
		{
			get { return modLineCollection; }
		}

		#endregion

		#region Ctor

		#endregion

		#region Public Methods

		public void AddItem(Product product, int quantity)
		{
			CartLine item = modLineCollection
								.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
			if(item == null)
			{
				modLineCollection.Add(new CartLine()
					{ Product = product, Quantity = quantity });
			}
			else
			{
				item.Quantity += quantity;
			}
		}

		public void RemoveLine(Product product)
		{
			modLineCollection.RemoveAll(x => x.Product.ProductID == product.ProductID);
		}

		public decimal ComputeTotalValue()
		{
			return modLineCollection.Sum(x => x.Product.Price * x.Quantity);
		}

		public void Clear()
		{
			modLineCollection.Clear();
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
	}

	public class CartLine
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
