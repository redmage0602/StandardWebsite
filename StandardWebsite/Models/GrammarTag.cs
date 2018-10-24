using System;

namespace StandardWebsite.Models
{
    public class GrammarTag
    {
        public int Id { get; set; }
        public int GrammarId { get; set; }
        public int TagId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public virtual Grammar Grammar { get; set; }
        public virtual Tag Tag { get; set; }
    }
}