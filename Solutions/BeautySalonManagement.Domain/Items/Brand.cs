using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Items
{
	[HasUniqueDomainSignature(ErrorMessage = "品牌已经存在")]
	public class Brand : Entity, IBrand
	{
		[DomainSignature]
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
	}
}