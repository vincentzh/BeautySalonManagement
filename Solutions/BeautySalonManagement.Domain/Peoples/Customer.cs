using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Peoples
{
	[HasUniqueDomainSignature(ErrorMessage = "客户卡号已经存在")]
	public class Customer : People
	{
		[DomainSignature]
		public virtual string CustomerCardNo { get; set; }
	}
}