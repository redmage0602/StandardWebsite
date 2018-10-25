using StandardWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace StandardWebsite.DAL
{
    public class GrammarDAL : BaseDAL
    {
        public Grammar GetById(int id, DeleteFlag deleteFlag)
        {
            try
            {
                Grammar grammar = DBContext.Grammars.SingleOrDefault(g => g.Id == id && g.DeleteFlag == deleteFlag);
                return grammar;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

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
                    grammars = grammars.Where(g => g.Content.Contains(search) || g.GrammarTags.Any(gm => gm.Tag.Content.Contains(search)));
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

        public Grammar Create(Grammar grammar)
        {
            try
            {
                if (grammar != null)
                {
                    DBContext.Grammars.Add(grammar);
                    DBContext.SaveChanges();

                    return GetById(grammar.Id, grammar.DeleteFlag);
                }

                return grammar;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public Grammar Update(Grammar grammar)
        {
            try
            {
                if (grammar != null)
                {
                    DBContext.GrammarTags.Where(gm => gm.GrammarId == grammar.Id).Delete();
                    DBContext.Entry(grammar).State = EntityState.Modified;
                    DBContext.SaveChanges();

                    return GetById(grammar.Id, grammar.DeleteFlag);
                }

                return grammar;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}