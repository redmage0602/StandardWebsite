﻿using StandardWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardWebsite.DAL
{
    public class TagDAL : BaseDAL
    {
        public List<Tag> GetAll(string search, int? sortColumn, string sortOrder, int skip, int take
            , DeleteFlag deleteFlag, out int total, out int filtered)
        {
            total = filtered = 0;

            try
            {
                IQueryable<Tag> tags = DBContext.Tags.Where(t => t.DeleteFlag == deleteFlag);
                total = tags.Count();

                if (!string.IsNullOrEmpty(search))
                {
                    tags = DBContext.Tags.Where(t => t.Content.Contains(search));
                }

                filtered = tags.Count();

                switch (sortColumn)
                {
                    case 1:
                        tags = sortOrder == "asc" ? tags.OrderBy(t => t.Content) : tags.OrderByDescending(t => t.Content);
                        break;

                    default:
                        break;
                }

                return tags.Skip(skip).Take(take).ToList();
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}