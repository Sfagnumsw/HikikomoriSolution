using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Http;

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

        public async Task<ServiceResponseEmpty> CreateUser(RegistrationViewModel user) //регистрация
        {
            try
            {
                var response = new ServiceResponseEmpty();
                var DbUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = user.UserName,
                    Email = user.Email,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                if (await _userManager.FindByEmailAsync(DbUser.Email) != null)
                {
                    response.Description = "Пользователь с такой почтой уже есть";
                    response.StatusCode = StatusCode.UserExists;
                    _userManager.Logger.LogInformation(response.Description); //!!!!!!!!!!!!!!!!!!!
                    return response;
                }

                if (await _userManager.FindByNameAsync(user.UserName) != null)
                {
                    response.Description = "Пользователь с таким логином уже есть";
                    response.StatusCode = StatusCode.UserExists;
                    _userManager.Logger.LogInformation(response.Description);             //!!!!!!!!!!!!!!!!!!!
                    return response;
                }

                var result = await _userManager.CreateAsync(DbUser, user.Password); //создаем юзера, добавлем ему роль, сохраняем его клаймы в БД (клаймы пока не нужны, сохраняю на всякий случай)
                await _userManager.AddToRoleAsync(DbUser, nameof(Roles.user));
                List<Claim> claimes = new List<Claim>()
                {
                    new Claim("Email", DbUser.Email),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, DbUser.UserName),
                };
                await _userManager.AddClaimsAsync(DbUser, claimes);
                response.Description = "Учетная запись создана, подтвердите почту";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                _userManager.Logger.LogError(ex.Message);                 //!!!!!!!!!!!!!!!!!!!!!
                return new ServiceResponseEmpty
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponseEmpty> SignIn(SignInViewModel model)
        {
            try
            {
                var response = new ServiceResponse<ClaimsPrincipal>();
                var user = await _userManager.FindByNameAsync(model.UserName);

                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        response.Description = "Успешный вход в систему";
                        response.StatusCode = StatusCode.OK;
                        return response;
                    }
                    else
                    {
                        response.Description = "Неверный логин или пароль";
                        response.StatusCode = StatusCode.Prohibited;
                        return response;
                    }
                }
                else
                {
                    response.Description = "Неверный логин или пароль";
                    response.StatusCode = StatusCode.Prohibited;
                    return response;
                }
            }
            catch (Exception ex)
            {
                _userManager.Logger.LogError(ex.Message); //!!!!!!!!!!!!!!!!!!!!!!
                return new ServiceResponseEmpty
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponseEmpty> SignOut()
        {
            try
            {
                var response = new ServiceResponseEmpty();
                await _signInManager.SignOutAsync();
                response.StatusCode = StatusCode.OK;
                response.Description = "Успешный выход из учетной записи";
                return response;
            }
            catch(Exception ex)
            {
                _userManager.Logger.LogError(ex.Message); //!!!!!!!!!!!!!!!!!!!!!!
                return new ServiceResponseEmpty
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponse<RegistrationViewModel>> GetUserData()
        {
            try
            {
                var response = new ServiceResponse<RegistrationViewModel>();
                var user = await GetCurrentUser();
                response.Description = "Данные пользователя получены";
                response.StatusCode = StatusCode.OK;
                response.Data = new RegistrationViewModel
                {
                    Email = user.Email,
                    UserName = user.UserName
                };
                return response;
            }
            catch(Exception ex)
            {
                _userManager.Logger.LogError(ex.Message);
                return new ServiceResponse<RegistrationViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }


        }

        public async Task<IdentityUser> GetCurrentUser()
        {
            var claims = _signInManager.Context.User;
            var user = await _userManager.GetUserAsync(claims);
            return user;
        }

        // Генерация ClimsPrincipal (похоже что нужна при аутентификации без Identity)
        // на основе утверждений о пользователе (claims);это происходит при входе в систему; метод принимает пользователя и его утверждения из БД
        private async Task<ClaimsPrincipal> Autheticate(IdentityUser user, IEnumerable<Claim> principal)
        {
            var claims = principal.ToList();
            var role = await _userManager.GetRolesAsync(user);
            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role[0]));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
