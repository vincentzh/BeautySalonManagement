using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Items
{
	public class Item : Entity, ISaleInfo
	{
		#region ISaleInfo Members

		public virtual string Name { get; set; }
		public virtual decimal Price { get; set; }
		public virtual decimal Cost { get; set; }

		#endregion

		public virtual ItemType Type { get; set; }
	}
}