using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class SignInViewModel //модель входа в систему
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
