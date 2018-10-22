using StandardWebsite.Common;
using System.Web.Mvc;

namespace StandardWebsite.Controllers
{
    [AccountAuthorization]
    public class GrammarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}