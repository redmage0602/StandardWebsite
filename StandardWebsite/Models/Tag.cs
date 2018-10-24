using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StandardWebsite.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DeleteFlag DeleteFlag { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        [Display(Name = "Number of Grammars")]
        public virtual List<GrammarTag> GrammarTags { get; set; }
    }
}