using StandardWebsite.Common;
using System.Web.Mvc;

namespace StandardWebsite.Controllers
{
    [AccountAuthorization]
    public class TagController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}