using StandardWebsite.BLL;
using StandardWebsite.Common;
using StandardWebsite.Models;
using System.Web.Mvc;

namespace StandardWebsite.Controllers
{
    [AccountAuthorization]
    public class GrammarController : Controller
    {
        private GrammarBLL _grammarBLL = new GrammarBLL();

        //
        // GET: /Grammar/Index
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Grammar/IndexAjax
        public ActionResult IndexAjax(JQueryDataTableRequest request)
        {
            JQueryDataTableResponse response = _grammarBLL.GetAll(request.sSearch, request.iSortCol_0, request.sSortDir_0
                , request.iDisplayStart, request.iDisplayLength, request.sEcho);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}