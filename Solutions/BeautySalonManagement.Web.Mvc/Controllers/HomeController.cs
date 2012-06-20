using BeautySalonManagement.Web.Mvc.Base;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class HomeController : CustomControllerBase
    {
        public ActionResult Index()
        {
			
            return View();
        }

    }
}
