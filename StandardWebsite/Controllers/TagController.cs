using StandardWebsite.BLL;
using StandardWebsite.Common;
using StandardWebsite.Models;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult IndexAjax(JQueryDataTableModel model)
        {
            int total, filtered;
            List<Tag> tags = _tagBLL.GetAll(model.sSearch, model.iSortCol_0, model.sSortDir_0, model.iDisplayStart
                , model.iDisplayLength, out total, out filtered);

            if (tags != null)
            {
                int i = model.iDisplayStart + 1;
                var data = from t in tags
                           let index = i++
                           select new[]
                           {
                               index.ToString(),
                               t.Content,
                               t.Id.ToString(),
                               t.Id.ToString(),
                               t.Id.ToString()
                           };

                return Json(new
                {
                    sEcho = model.sEcho,
                    iTotalRecords = total,
                    iTotalDisplayRecords = filtered,
                    aaData = data
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                sEcho = model.sEcho,
                iTotalRecords = total,
                iTotalDisplayRecords = filtered,
                aaData = new string[] { }
            }, JsonRequestBehavior.AllowGet);
        }
    }
}