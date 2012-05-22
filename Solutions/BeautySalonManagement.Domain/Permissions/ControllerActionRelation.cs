using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Permissions
{
	[HasUniqueDomainSignature(ErrorMessage = "Controller And Action Relationship exsit")]
	public class ControllerActionRelation : Entity
	{
		protected ControllerActionRelation(){}
		public ControllerActionRelation(ControllerNameEnum controller, ActionNameEnum action)
		{
			ControllerName = controller.Name.ToLower();
			ActionName = action.Name.ToLower();
		}

		[DomainSignature]
		public virtual string ControllerName { get; protected set; }

		[DomainSignature]
		public virtual string ActionName { get; protected set; }
	}
}