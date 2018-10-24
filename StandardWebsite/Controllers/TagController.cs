using StandardWebsite.BLL;
using StandardWebsite.Common;
using StandardWebsite.Models;
using System.Web.Mvc;

namespace StandardWebsite.Controllers
{
    [AccountAuthorization]
    public class TagController : Controller
    {
        private TagBLL _tagBLL = new TagBLL();

        //
        // GET: /Tag/Index
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tag/IndexAjax
        public ActionResult IndexAjax(JQueryDataTableRequest request)
        {
            JQueryDataTableResponse response = _tagBLL.GetAll(request.sSearch, request.iSortCol_0, request.sSortDir_0
                , request.iDisplayStart, request.iDisplayLength, request.sEcho);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}