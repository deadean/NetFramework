﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
	public class ShippingDetails
	{

		#region Fields

		#endregion

		#region Properties

		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter the first address line")]
		[Display(Name = "Line 1")]
		public string Line1 { get; set; }

		[Display(Name = "Line 2")]
		public string Line2 { get; set; }

		[Display(Name = "Line 3")]
		public string Line3 { get; set; }

		[Required(ErrorMessage = "Please enter a country name")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Please enter the city name")]
		public string City { get; set; }

		[Required(ErrorMessage = "Please enter the state name")]
		public string State { get; set; }

		public string Zip { get; set; }
		public bool GiftWrap { get; set; }

		#endregion

		#region Ctor

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
	}
}
