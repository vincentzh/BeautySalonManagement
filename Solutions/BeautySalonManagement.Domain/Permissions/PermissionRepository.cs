using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Domain.Permissions
{
	public class PermissionRepository : IPermissionRepository
	{
		IEnumerable<ControllerActionRelation> relations = new Collection<ControllerActionRelation>();
		IRepository<ControllerActionRelation> RelationRepository;
		public PermissionRepository(IRepository<ControllerActionRelation> relationRepo )
		{
			RelationRepository = relationRepo;
			if (relations.Count() == 0)
				GetControllerActionRelations();
		}
		public void ReLoadRepository()
		{
			GetControllerActionRelations();
		}

		void GetControllerActionRelations()
		{
			relations = RelationRepository.GetAll();
		}

		public bool HasPermission(string controllerName, string actionName, PermissionGroup permission = null)
		{
			if (permission == null)
				return
						relations.FirstOrDefault(x =>
						                         x.ControllerName.Equals(controllerName, StringComparison.OrdinalIgnoreCase) &&
						                         x.ActionName.Equals(actionName, StringComparison.OrdinalIgnoreCase)) == null;

			else
				return
						permission.PermissionGroupAndControllerActionRelations.FirstOrDefault(
								x =>
								x.ControllerActionRelation.ControllerName.Equals(controllerName, StringComparison.OrdinalIgnoreCase) &&
								x.ControllerActionRelation.ActionName.Equals(actionName, StringComparison.OrdinalIgnoreCase)) != null;
		}
	}
}