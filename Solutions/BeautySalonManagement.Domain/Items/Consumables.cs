#region

using BeautySalonManagement.Domain.Interfaces;
using SharpArch.Domain.DomainModel;

#endregion

namespace BeautySalonManagement.Domain.Items
{
	public class Consumables : Entity, ISaleInfo
	{
		#region ISaleInfo Members

		public virtual string Name { get; set; }

		public virtual string Description { get; set; }

		public virtual decimal Price { get; set; }

		public virtual bool Disable { get; set; }

		#endregion
	}
}