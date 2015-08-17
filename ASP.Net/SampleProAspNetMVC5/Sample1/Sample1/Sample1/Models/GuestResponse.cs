using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.Models
{
	public class GuestResponse
	{
		public string Phone { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public bool? WillAttend { get; set; }
	}
}
