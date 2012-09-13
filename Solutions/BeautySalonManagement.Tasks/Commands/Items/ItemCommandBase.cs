using BeautySalonManagement.Domain.Articles;
using SharpArch.Domain.Commands;

namespace BeautySalonManagement.Tasks.Commands.Items
{
	public class ItemCommandBase : CommandBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Cost { get; set; }
		public ItemType ItemType { get; set; }
		public int BrandId { get; set; }
		public bool Disable { get; set; }
		
	}
}