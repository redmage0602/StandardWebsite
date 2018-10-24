using StandardWebsite.DAL;
using StandardWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace StandardWebsite.BLL
{
    public class TagBLL : BaseBLL
    {
        private TagDAL _tagDAL = new TagDAL();

        public List<Tag> GetAll()
        {
            return _tagDAL.GetAll(DeleteFlag.Active);
        }

        public JQueryDataTableResponse GetAll(string search, int? sortColumn, string sortOrder, int skip, int take, string sEcho)
        {
            int total, filtered;
            List<Tag> tags = _tagDAL.GetAll(search, sortColumn, sortOrder, skip, take, DeleteFlag.Active, out total, out filtered);
            IEnumerable<string[]> data = new List<string[]>();

            if (tags != null)
            {
                int i = skip + 1;
                data = from t in tags
                       let index = i++
                       select new[]
                       {
                           index.ToString(),
                           t.Content,
                           t.GrammarTags.Count.ToString(),
                           t.Id.ToString(),
                           t.Id.ToString(),
                           t.Id.ToString()
                       };
            }

            JQueryDataTableResponse response = new JQueryDataTableResponse()
            {
                sEcho = sEcho,
                iTotalRecords = total,
                iTotalDisplayRecords = filtered,
                aaData = data
            };

            return response;
        }
    }
}