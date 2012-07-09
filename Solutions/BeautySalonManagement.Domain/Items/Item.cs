using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Items
{
	[HasUniqueDomainSignature(ErrorMessage = "同款物品已经存在")]
	public class Item : Entity, IItem
	{
		#region ISaleInfo Members
		[DomainSignature]
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual decimal Price { get; set; }
		public virtual decimal Cost { get; set; }
		public virtual bool Disable { get; set; }

		#endregion
		[DomainSignature]
		public virtual ItemType Type { get; set; }
		public virtual IBrand Brand { get; set; }
	}
}