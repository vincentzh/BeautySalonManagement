using MindHarbor.ClassEnum;

namespace BeautySalonManagement.Domain.Items
{
	public class ItemType : ClassEnumGeneric<ItemType>
	{
		public static readonly ItemType Consumble = new ItemType("consumable", "易耗品");
		public static readonly ItemType Product = new ItemType("product", "商品");

		ItemType(string name, string desc) : base(name)
		{
			Desc = desc;
		}

		public string Desc { get; set; }
	}
}