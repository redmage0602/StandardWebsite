using StandardWebsite.Models;

namespace StandardWebsite.DAL
{
    public class BaseDAL
    {
        protected StandardWebsiteContext DBContext = new StandardWebsiteContext();
    }
}