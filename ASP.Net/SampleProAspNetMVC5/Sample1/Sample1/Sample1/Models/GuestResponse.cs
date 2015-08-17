using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.Models
{
	public class GuestResponse
	{
		[Required(ErrorMessage = "Please, enter your phone")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please, enter your name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please, enter your email")]
		[RegularExpression(".+\\@.+\\..+", ErrorMessage ="Please, enter a valid email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please, specify whether you will attend")]
		public bool? WillAttend { get; set; }
	}
}
