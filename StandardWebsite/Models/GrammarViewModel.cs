using System.ComponentModel.DataAnnotations;

namespace StandardWebsite.Models
{
    public class GrammarViewModel
    {
        [MaxLength(32)]
        [Required]
        public string Content { get; set; }

        [Required]
        public int[] Tags { get; set; }
    }
}