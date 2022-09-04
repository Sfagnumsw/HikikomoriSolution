using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Entity
{
    public class Categories
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }
    }
}
