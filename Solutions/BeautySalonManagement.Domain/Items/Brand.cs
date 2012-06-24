using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Items
{
	public class Brand : Entity, IBrand
	{
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
	}
}