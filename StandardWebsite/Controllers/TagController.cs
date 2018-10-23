using StandardWebsite.BLL;
using StandardWebsite.Common;
using StandardWebsite.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StandardWebsite.Controllers
{
    [AccountAuthorization]
    public class TagController : Controller
    {
        private TagBLL _tagBLL = new TagBLL();

        public ActionResult Index()
        {
            List<Tag> tags = _tagBLL.GetAll();

            if (tags != null)
            {
                return View(tags);
            }

            return View("Error");
        }
    }
}