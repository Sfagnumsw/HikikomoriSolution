using System;
using System.ComponentModel.DataAnnotations;
using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ViewModels
{
    public abstract class AbstractContentViewModel //шаблон формы заполнения 
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Автор")]
        public string Autor { get; set; }

        [Range(1800, 3000, ErrorMessage = "Введите корректный год")]
        [Display(Name = "Год выпуска")]
        public int CreationYear { get; set; }

        [Required(ErrorMessage = "Выберете категорию")]
        [Display(Name = "Категория")]
        public Categories CategoryId { get; set; }
    }
}
