#region

using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

#endregion

namespace BeautySalonManagement.Domain.Permissions
{
	[HasUniqueDomainSignature(ErrorMessage = "权限已经存在")]
	public class PermissionItem : Entity
	{
		protected PermissionItem()
		{}

		public PermissionItem(PermissionDescription desc, PermissionBehavior behavior)
		{
			Description = desc;
			Behavior = behavior;
		}
		 [DomainSignature]
		public virtual PermissionDescription Description { get; protected set; }
		 [DomainSignature]
		public virtual PermissionBehavior Behavior { get; protected set; }
	}
}