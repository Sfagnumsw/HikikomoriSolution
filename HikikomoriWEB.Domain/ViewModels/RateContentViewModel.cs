using System;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class RateContentViewModel : AbstractContentViewModel //оцененный
    {
        [Display(Name = "Флаг пересмотра")]
        public bool Replay { get; set; }

        [Range(0, 10, ErrorMessage = "Оцените по десятибальной шкале")]
        [Display(Name = "Оценка")]
        public int Rating { get; set; }
    }
}
