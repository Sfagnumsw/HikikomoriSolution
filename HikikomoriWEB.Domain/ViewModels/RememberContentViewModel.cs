using System;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class RememberContentViewModel
    {
        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public virtual string Name { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Автор")]
        public string Autor { get; set; }

        [Range(1880, 3000, ErrorMessage = "Введите корректный год")]
        [Display(Name = "Год выпуска")]
        public int CreationYear { get; set; }

        [Required(ErrorMessage = "Выберете категорию")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
    }
}
