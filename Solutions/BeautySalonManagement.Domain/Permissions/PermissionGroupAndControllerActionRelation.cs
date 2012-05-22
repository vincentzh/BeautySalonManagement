using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Permissions
{
	[HasUniqueDomainSignature(ErrorMessage = "it's should unique",ErrorMessageResourceType = typeof(PermissionGroupAndControllerActionRelation))]
	public class PermissionGroupAndControllerActionRelation : Entity
	{
		[DomainSignature]
		public virtual PermissionGroup PermissionGroup { get; set; }

		[DomainSignature]
		public virtual ControllerActionRelation ControllerActionRelation { get; set; }
	}
}