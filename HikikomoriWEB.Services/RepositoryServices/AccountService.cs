using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using System;
using System.Security.Claims;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> user, SignInManager<IdentityUser> signIdData)
        {
            _userManager = user;
            _signInManager = signIdData;
        }

        public async Task<ServiceResponseBase> CreateUser(RegistrationViewModel user) //регистрация
        {
            try
            {
                var DbUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = user.UserName,
                    Email = user.Email,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var statusExistence = await CheckUserExists(DbUser);
                if (statusExistence.StatusCode != StatusCode.OK) return statusExistence;
                await _userManager.CreateAsync(DbUser, user.Password);
                await _userManager.AddToRoleAsync(DbUser, nameof(Roles.user));
                return new ServiceResponseBase("Учетная запись создана, подтвердите почту", StatusCode.OK);
            }
            catch (Exception ex)
            {
                return new ServiceResponseBase(ex.Message, StatusCode.ServerError);
            }
        }

        public async Task<ServiceResponseBase> SignIn(SignInViewModel model) //вход
        {
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded) return new ServiceResponseBase("Успешный вход в систему", StatusCode.OK);
                return new ServiceResponseBase("Неверный логин или пароль", StatusCode.Prohibited);
            }
            catch (ArgumentNullException)
            {
                return new ServiceResponseBase("Неверный логин или пароль", StatusCode.Prohibited);
            }
            catch (Exception ex)
            {
                return new ServiceResponseBase(ex.Message, StatusCode.ServerError);
            }
        }

        public async Task<ServiceResponseBase> SignOut() //выход
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new ServiceResponseBase(StatusCode.OK);
            }
            catch (Exception ex)
            {
                return new ServiceResponseBase(ex.Message, StatusCode.ServerError);
            }
        }

        public async Task<ServiceResponse<IdentityUser>> GetCurrentUser() //текущий пользователь
        {
            ClaimsPrincipal claims = _signInManager.Context.User;
            IdentityUser user = await _userManager.GetUserAsync(claims);
            return new ServiceResponse<IdentityUser>(StatusCode.OK, user);
        }

        private async Task<ServiceResponseBase> CheckUserExists(IdentityUser user) //проверка пользователя на уникальные mail и userName
        {
            if (await _userManager.FindByEmailAsync(user.Email) != null) return new ServiceResponseBase("Пользователь с такой почтой уже существует", StatusCode.UserExists);
            else if (await _userManager.FindByNameAsync(user.UserName) != null) return new ServiceResponseBase("Пользователь с таким логином уже существует", StatusCode.UserExists);
            else return new ServiceResponseBase(StatusCode.OK);
        }
    }
}