using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
	[Table("T_Sneaker")]
	public class Sneaker
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Brand { get; set; }  = string.Empty;
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Description { get; set; } = string.Empty;
		public bool EstDispo { get; set; }
	}
}
