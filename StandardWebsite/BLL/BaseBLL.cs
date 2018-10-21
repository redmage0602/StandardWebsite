using System.Web;
using System.Web.SessionState;

namespace StandardWebsite.BLL
{
    public class BaseBLL
    {
        protected HttpSessionState Session = HttpContext.Current.Session;
    }
}