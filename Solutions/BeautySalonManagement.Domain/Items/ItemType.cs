using MindHarbor.ClassEnum;

namespace BeautySalonManagement.Domain.Items
{
	public class ItemType : ClassEnumGeneric<ItemType>
	{
		public static readonly ItemType ForSale = new ItemType("ForSale", "客装");
		public static readonly ItemType NotForSale=new ItemType("NotForSale","院装");

		ItemType(string name, string desc) : base(name)
		{
			Desc = desc;
		}

		public string Desc { get; set; }
	}
}