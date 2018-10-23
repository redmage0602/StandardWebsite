using StandardWebsite.DAL;
using StandardWebsite.Models;
using System.Collections.Generic;

namespace StandardWebsite.BLL
{
    public class TagBLL : BaseBLL
    {
        private TagDAL _tagDAL = new TagDAL();

        public List<Tag> GetAll()
        {
            return _tagDAL.GetAll(DeleteFlag.Active);
        }
    }
}