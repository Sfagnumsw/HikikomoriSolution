using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Enum
{
    public enum Categories
    {
        [Display(Name = "Фильмы")]
        Films = 10000,

        [Display(Name = "Книги")]
        Books = 10001,

        [Display(Name = "Игры")]
        Games = 10002,

        [Display(Name = "Сериалы")]
        Serials = 10003,

        [Display(Name = "Мультфильмы")]
        Cartoons = 10004
    }
}
