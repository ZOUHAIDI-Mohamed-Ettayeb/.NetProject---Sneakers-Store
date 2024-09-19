using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Sneaker
{
	public class AdminSneakerAddVM
	{
		[Required(ErrorMessage = "Saisir le nom de produit")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Description")]
		public string Description { get; set; } = string.Empty;
		[Required(ErrorMessage = "Brand")]
		public string Brand { get; set; } = string.Empty;

		[Range(1, 10000)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
		
		public bool EstDisp { get; set; }
		

	}
}
