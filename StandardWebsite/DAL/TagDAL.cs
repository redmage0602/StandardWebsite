using StandardWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardWebsite.DAL
{
    public class TagDAL : BaseDAL
    {
        public List<Tag> GetAll(DeleteFlag deleteFlag)
        {
            try
            {
                List<Tag> tags = DBContext.Tags.Where(t => t.DeleteFlag == deleteFlag).ToList();
                return tags;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}