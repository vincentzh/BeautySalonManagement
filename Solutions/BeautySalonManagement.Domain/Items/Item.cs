using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Items
{
	public class Item : Entity, IItem
	{
		#region ISaleInfo Members

		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual decimal Price { get; set; }
		public virtual decimal Cost { get; set; }
		public virtual bool Disable { get; set; }

		#endregion

		public virtual ItemType Type { get; set; }
		public virtual IBrand Brand { get; set; }
	}
}