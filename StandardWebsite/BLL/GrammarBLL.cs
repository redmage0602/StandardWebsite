using StandardWebsite.DAL;
using StandardWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace StandardWebsite.BLL
{
    public class GrammarBLL : BaseBLL
    {
        private GrammarDAL _grammarDAL = new GrammarDAL();

        public JQueryDataTableResponse GetAll(string search, int? sortColumn, string sortOrder, int skip, int take, string sEcho)
        {
            int total, filtered;
            List<Grammar> grammars = _grammarDAL.GetAll(search, sortColumn, sortOrder, skip, take, DeleteFlag.Active, out total, out filtered);
            IEnumerable<string[]> data = new List<string[]>();

            if (grammars != null)
            {
                int i = skip + 1;
                data = from g in grammars
                       let index = i++
                       select new[]
                       {
                           index.ToString(),
                           g.Content,
                           g.Id.ToString(),
                           g.Id.ToString(),
                           g.Id.ToString()
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