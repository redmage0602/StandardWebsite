using StandardWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardWebsite.DAL
{
    public class GrammarDAL : BaseDAL
    {
        public List<Grammar> GetAll(string search, int? sortColumn, string sortOrder, int skip, int take
            , DeleteFlag deleteFlag, out int total, out int filtered)
        {
            total = filtered = 0;

            try
            {
                IQueryable<Grammar> grammars = DBContext.Grammars.Where(g => g.DeleteFlag == deleteFlag);
                total = grammars.Count();

                if (!string.IsNullOrEmpty(search))
                {
                    grammars = grammars.Where(g => g.Content.Contains(search));
                }

                filtered = grammars.Count();

                switch (sortColumn)
                {
                    case 1:
                        grammars = sortOrder == "asc" ? grammars.OrderBy(g => g.Content) : grammars.OrderByDescending(g => g.Content);
                        break;

                    default:
                        break;
                }

                return grammars.Skip(skip).Take(take).ToList();
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}