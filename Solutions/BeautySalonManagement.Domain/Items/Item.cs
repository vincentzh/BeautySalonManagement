#region

using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

#endregion

namespace BeautySalonManagement.Domain.Items
{
	[HasUniqueDomainSignature(ErrorMessage = "同款物品已经存在")]
	public class Item : Entity, IItem
	{
		[DomainSignature]
		public virtual ItemType Type { get; set; }

		#region IItem Members

		[DomainSignature]
		public virtual string Name { get; set; }

		public virtual string Description { get; set; }
		public virtual decimal Price { get; set; }

		public virtual bool Disable { get; set; }

		public virtual IBrand Brand { get; set; }
		[DomainSignature]
		public virtual decimal Volume { get; set; }

		#endregion
	}
}