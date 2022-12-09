using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IAccountService //сервис управления пользователями                             
    {
        Task<ServiceResponseEmpty> CreateUser(RegistrationViewModel userData); //создание пользователя
        Task<ServiceResponseEmpty> SignIn(SignInViewModel userData); //вход
        Task<ServiceResponseEmpty> SignOut(); //выход
        Task<IdentityUser> GetCurrentUser(); //получить текущего актвного юзера
        Task<ServiceResponse<RegistrationViewModel>> GetUserData();
    }
}
