using StandardWebsite.DAL;
using StandardWebsite.Models;
using System.Collections.Generic;

namespace StandardWebsite.BLL
{
    public class TagBLL : BaseBLL
    {
        private TagDAL _tagDAL = new TagDAL();

        public List<Tag> GetAll(string search, int? sortColumn, string sortOrder, int skip, int take, out int total, out int filtered)
        {
            return _tagDAL.GetAll(search, sortColumn, sortOrder, skip, take, DeleteFlag.Active, out total, out filtered);
        }
    }
}