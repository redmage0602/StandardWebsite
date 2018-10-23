using StandardWebsite.Common;
using System.Web.Mvc;

namespace StandardWebsite.Controllers
{
    [AccountAuthorization]
    public class GrammarController : Controller
    {
        //
        // GET: /Grammar/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}