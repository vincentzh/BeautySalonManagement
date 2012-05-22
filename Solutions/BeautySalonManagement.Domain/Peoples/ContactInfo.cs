using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Peoples
{
	public class ContactInfo : ValueObject
	{
		public virtual string Name { get; set; }
		public virtual string Phone { get; set; }
	}
}