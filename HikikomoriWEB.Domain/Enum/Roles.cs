using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Enum
{
    public enum Roles
    {
        [Display(Name = "Админ")]
        Admin = 0,

        [Display(Name = "Пользователь")]
        User = 1
    }
}
