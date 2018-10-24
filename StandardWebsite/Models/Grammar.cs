using System;

namespace StandardWebsite.Models
{
    public class Grammar
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DeleteFlag DeleteFlag { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }
    }
}