using System.Web.Mvc;
using BeautySalonManagement.Domain;
using BeautySalonManagement.Domain.Permissions;
using Microsoft.Practices.ServiceLocation;

namespace BeautySalonManagement.Web.Mvc.Attributes
{
	public class CustomPermissionAttribute : ActionFilterAttribute
	{
		IPermissionRepository _PermissionRepository;

		public CustomPermissionAttribute()
		{
			_PermissionRepository = ServiceLocator.Current.GetInstance<IPermissionRepository>();
		}
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!HasPermission(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName))
			{
				filterContext.Result = new HttpUnauthorizedResult("没有访问权限");
			}
		}

		bool HasPermission(string controllerName,string actionName)
		{
			if (DomainSession.Current.People == null)
				return _PermissionRepository.HasPermission(controllerName,actionName);
			return _PermissionRepository.HasPermission(controllerName, actionName, DomainSession.Current.People.PermissionGroup);
		}
	}
}