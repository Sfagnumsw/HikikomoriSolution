using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Enum
{
    public enum Roles //роли пользователей для авторизации
    {
        [Display(Name = "Пользователь")]
        admin = 1,

        [Display(Name = "Админ")]
        user = 2,

        [Display(Name = "Модератор")]
        moder = 3
    }
}
