using MindHarbor.ClassEnum;

namespace BeautySalonManagement.Domain.Articles
{
	public class ItemType : ClassEnumGeneric<ItemType>
	{
		public static readonly ItemType Consumble = new ItemType("consumable", "易耗品");
		public static readonly ItemType Product = new ItemType("product", "商品");
		public static readonly ItemType Service=new ItemType("service","服务");
		ItemType(string name, string desc) : base(name)
		{
			Desc = desc;
		}

		public string Desc { get; set; }
	}
}