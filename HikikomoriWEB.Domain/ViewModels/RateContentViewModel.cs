using System;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class RateContentViewModel
    {
        [Required (ErrorMessage = "Введите название")]
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

        [Display(Name = "Флаг пересмотра")]
        public bool Replay { get; set; }

        [Range(0, 10, ErrorMessage = "Оцените по десятибальной шкале")]
        [Display(Name = "Оценка")]
        public int Rating { get; set; }
    }
}
