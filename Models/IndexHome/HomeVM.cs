
namespace Models.IndexHome
{
	public class HomeVM
	{
		public class SneakerHomeVM
		{
			public int Id { get; set; }
			public string Name { get; set; } = string.Empty;
			public string Brand { get; set; } = string.Empty;
			public string Description { get; set; } = string.Empty;
			public decimal Price { get; set; }
		}
		public List<SneakerHomeVM> Produit { get; set; }
	}
}
