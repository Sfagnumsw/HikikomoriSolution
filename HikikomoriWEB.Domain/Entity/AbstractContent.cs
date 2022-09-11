using HikikomoriWEB.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Entity
{
    public abstract class AbstractContent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public virtual string Name { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Автор")]
        public string Autor { get; set; }

        [Display(Name = "Год выпуска")]
        public int CreationYear { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
    }
}
