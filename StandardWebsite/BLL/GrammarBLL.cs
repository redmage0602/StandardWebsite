using StandardWebsite.DAL;
using StandardWebsite.Models;
using System;
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
                           string.Join(", ", g.GrammarTags.Select(gm => gm.Tag.Content).ToArray()),
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

        public Grammar Create(string content, int[] tagIds)
        {
            if (!string.IsNullOrEmpty(content) && tagIds.Count() > 0)
            {
                int accountId;
                int.TryParse(Session["accountId"].ToString(), out accountId);

                Grammar grammar = new Grammar()
                {
                    Content = content,
                    DeleteFlag = DeleteFlag.Active,
                    CreatedDate = DateTime.Now,
                    CreatedUser = accountId,
                    GrammarTags = new List<GrammarTag>()
                };

                foreach (int id in tagIds)
                {
                    GrammarTag grammarTag = new GrammarTag()
                    {
                        GrammarId = grammar.Id,
                        TagId = id,
                        CreatedDate = DateTime.Now,
                        CreatedUser = accountId
                    };

                    grammar.GrammarTags.Add(grammarTag);
                }

                return _grammarDAL.Create(grammar);
            }

            return null;
        }
    }
}