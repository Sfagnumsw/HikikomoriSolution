using Microsoft.AspNetCore.Identity;
using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IAccountService //сервис управления пользователями                             
    {
        Task<ServiceResponseEmpty> CreateUser(RegistrationViewModel userData); //создание пользователя
        Task<ServiceResponse<ClaimsIdentity>> SignIn(SignInViewModel userData); //вход
        Task<ServiceResponseEmpty> SignOut(string scheme); //выход
    }
}
