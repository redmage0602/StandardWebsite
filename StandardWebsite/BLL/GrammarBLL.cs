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

        public GrammarViewModel GetById (int id)
        {
            Grammar grammar = _grammarDAL.GetById(id, DeleteFlag.Active);
            GrammarViewModel viewModel = null;

            if (grammar != null)
            {
                viewModel = new GrammarViewModel()
                {
                    Id = grammar.Id,
                    Content = grammar.Content,
                    Examples = grammar.Examples,
                    Tags = grammar.GrammarTags.Select(gm => gm.Tag.Id).ToArray()
                };
            }

            return viewModel;
        }

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

        public Grammar Create(string content, int[] tagIds, string examples)
        {
            if (!string.IsNullOrEmpty(content) && tagIds.Count() > 0)
            {
                int accountId;
                int.TryParse(Session["accountId"].ToString(), out accountId);

                Grammar grammar = new Grammar()
                {
                    Content = content.Trim(),
                    Examples = examples,
                    DeleteFlag = DeleteFlag.Active,
                    CreatedDate = DateTime.Now,
                    CreatedUser = accountId,
                    GrammarTags = new List<GrammarTag>()
                };

                foreach (int tagId in tagIds)
                {
                    GrammarTag grammarTag = new GrammarTag()
                    {
                        GrammarId = grammar.Id,
                        TagId = tagId,
                        CreatedDate = DateTime.Now,
                        CreatedUser = accountId
                    };

                    grammar.GrammarTags.Add(grammarTag);
                }

                return _grammarDAL.Create(grammar);
            }

            return null;
        }

        public Grammar Update(int id, string content, int[] tagIds, string examples)
        {
            if (!string.IsNullOrEmpty(content) && tagIds.Count() > 0)
            {
                int accountId;
                int.TryParse(Session["accountId"].ToString(), out accountId);

                Grammar grammar = _grammarDAL.GetById(id, DeleteFlag.Active);

                if (grammar != null)
                {
                    grammar.Content = content.Trim();
                    grammar.Examples = examples;
                    grammar.UpdatedDate = DateTime.Now;
                    grammar.UpdatedUser = accountId;
                    grammar.GrammarTags = new List<GrammarTag>();

                    foreach (int tagId in tagIds)
                    {
                        GrammarTag grammarTag = new GrammarTag()
                        {
                            GrammarId = grammar.Id,
                            TagId = tagId,
                            CreatedDate = DateTime.Now,
                            CreatedUser = accountId
                        };

                        grammar.GrammarTags.Add(grammarTag);
                    }

                    return _grammarDAL.Update(grammar);
                }
            }

            return null;
        }
    }
}