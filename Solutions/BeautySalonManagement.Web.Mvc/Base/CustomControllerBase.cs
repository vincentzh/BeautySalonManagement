using System.Web.Mvc;
using BeautySalonManagement.Web.Mvc.Attributes;

namespace BeautySalonManagement.Web.Mvc.Base
{
	[CustomPermission]
	public class CustomControllerBase : Controller
	{}
}