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
        private TagBLL _tagBLL = new TagBLL();

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

        //
        // GET: /Grammar/Create
        public ActionResult Create()
        {
            ViewBag.Tags = _tagBLL.GetAll();
            return View();
        }

        //
        // POST: /Grammar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GrammarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Grammar grammar =  _grammarBLL.Create(viewModel.Content, viewModel.Tags, viewModel.Examples);

                if (grammar != null)
                {
                    TempData["MessageType"] = "success";
                    TempData["Message"] = "Create grammar successfully!";

                    return RedirectToAction("update", new { id = grammar.Id });
                }

                ViewBag.ErrorMessage = "Create grammar failed. Please try again!";
            }

            ViewBag.Tags = _tagBLL.GetAll();
            return View(viewModel);
        }

        //
        // GET: /Grammar/Update
        public ActionResult Update(int id)
        {
            GrammarViewModel viewModel = _grammarBLL.GetById(id);

            if (viewModel != null)
            {
                ViewBag.Tags = _tagBLL.GetAll();
                return View(viewModel);
            }

            return View("error");
        }

        //
        // POST: /Grammar/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GrammarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Grammar grammar = _grammarBLL.Update(viewModel.Id, viewModel.Content, viewModel.Tags, viewModel.Examples);

                if (grammar != null)
                {
                    TempData["MessageType"] = "success";
                    TempData["Message"] = "Update grammar successfully!";

                    return RedirectToAction("update", new { id = grammar.Id });
                }

                TempData["MessageType"] = "error";
                TempData["Message"] = "Update grammar failed. Please try again!";
            }

            ViewBag.Tags = _tagBLL.GetAll();
            return View(viewModel);
        }
    }
}