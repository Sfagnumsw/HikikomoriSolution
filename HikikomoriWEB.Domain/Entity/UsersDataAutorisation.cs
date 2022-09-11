using HikikomoriWEB.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Entity
{
    public class UsersDataAutorisation
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Почта")]
        public int Email { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Роль")]
        public int Role { get; set; }
    }
}
