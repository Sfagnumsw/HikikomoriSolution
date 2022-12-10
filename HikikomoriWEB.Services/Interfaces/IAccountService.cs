using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IAccountService //сервис управления пользователями                             
    {
        Task<ServiceResponseBase> CreateUser(RegistrationViewModel userData); //создание пользователя
        Task<ServiceResponseBase> SignIn(SignInViewModel userData); //вход
        Task<ServiceResponseBase> SignOut(); //выход
        Task<ServiceResponse<IdentityUser>> GetCurrentUser(); //получить текущего актвного юзера
    }
}
