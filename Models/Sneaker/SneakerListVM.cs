using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Sneaker
{
	public class SneakerListVM
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;
		public string Brand { get; set; } = String.Empty;
		public decimal Price { get; set; }
		public string Description { get; set; } = String.Empty;
		public bool EstDispo { get; set; }
	}
}
