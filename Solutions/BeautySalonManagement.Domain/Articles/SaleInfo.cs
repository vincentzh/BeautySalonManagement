#region

using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;


namespace BeautySalonManagement.Domain.Articles

#endregion


{
	[HasUniqueDomainSignature(ErrorMessage = "该名称已经存在")]
	public class SaleInfo : Entity, ISaleInfo
	{
		[DomainSignature]
		public virtual ItemType Type { get; set; }

		[DomainSignature]
		public virtual string Name { get; set; }

		public virtual string Description { get; set; }
		public virtual decimal Price { get; set; }
		public virtual decimal Cost { get; set; }
		public virtual bool Disable { get; set; }

	}
}