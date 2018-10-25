using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StandardWebsite.Models
{
    public class GrammarViewModel
    {
        public int Id { get; set; }

        [MaxLength(32)]
        [Required]
        public string Content { get; set; }

        [Required]
        public int[] Tags { get; set; }

        [AllowHtml]
        [MaxLength(256)]
        public string Examples { get; set; }
    }
}