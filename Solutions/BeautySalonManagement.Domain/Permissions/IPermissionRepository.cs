namespace BeautySalonManagement.Domain.Permissions
{
	public interface IPermissionRepository
	{
		void ReLoadRepository();
		bool HasPermission(string controllerName, string actionName, PermissionGroup permission = null);
	}
}