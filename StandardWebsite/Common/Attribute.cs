using System.Web;
using System.Web.Mvc;

namespace StandardWebsite.Common
{
    public class AccountAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return HttpContext.Current.Session["accountId"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            filterContext.Result = new RedirectResult(urlHelper.Action("signin", "account"
                , new { redirectUrl = filterContext.HttpContext.Request.RawUrl }));
        }
    }
}