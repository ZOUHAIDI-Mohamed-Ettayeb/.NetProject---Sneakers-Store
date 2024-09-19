using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
	[Table("T_User")]
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Compte { get; set; } = string.Empty;
		[Required]
		public string MotPasse { get; set; } = string.Empty;
	}
}
