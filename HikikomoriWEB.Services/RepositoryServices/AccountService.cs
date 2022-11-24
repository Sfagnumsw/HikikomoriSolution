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

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IdentityUser> _logger;

        public AccountService(UserManager<IdentityUser> user, SignInManager<IdentityUser> signIdData, ILogger<IdentityUser> logger)
        {
            _userManager = user;
            _signInManager = signIdData;
            _logger = logger;
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
                    _logger.LogInformation(response.Description);             //!!!!!!!!!!!!!!!!!!!
                    return response;
                }

                if (await _userManager.FindByNameAsync(user.UserName) != null)
                {
                    response.Description = "Пользователь с таким логином уже есть";
                    response.StatusCode = StatusCode.UserExists;
                    _logger.LogInformation(response.Description);             //!!!!!!!!!!!!!!!!!!!
                    return response;
                }

                var result = await _userManager.CreateAsync(DbUser, user.Password); // создаем пользователя, добавляем в таблицу ролей пользователя и его роль, входим в систему, добавляем claims в БД
                await _userManager.AddToRoleAsync(DbUser, nameof(Roles.user));
                Claim claim = new Claim(ClaimTypes.Email, DbUser.Email);
                await _userManager.AddClaimAsync(DbUser, claim);
                response.Description = "Учетная запись создана, подтвердите почту";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);                 //!!!!!!!!!!!!!!!!!!!!!
                return new ServiceResponseEmpty
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponse<ClaimsIdentity>> SignIn(SignInViewModel model)
        {
            try
            {
                var response = new ServiceResponse<ClaimsIdentity>();
                var user = await _userManager.FindByNameAsync(model.UserName);

                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        IEnumerable<Claim> claims = await _userManager.GetClaimsAsync(user);
                        var cookies = await Autheticate(user, claims);
                        response.Description = "Успешный вход в систему";
                        response.StatusCode = StatusCode.OK;
                        response.Data = cookies;
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
                _logger.LogInformation(ex.Message); //!!!!!!!!!!!!!!!!!!!!!!
                return new ServiceResponse<ClaimsIdentity>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponseEmpty> SignOut(string scheme)
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
                _logger.LogInformation(ex.Message); //!!!!!!!!!!!!!!!!!!!!!!
                return new ServiceResponseEmpty
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        // Генерация куки
        // на основе утверждений о пользователе (claims);это происходит при входе в систему; метод принимает пользователя и его утверждения из БД
        private async Task<ClaimsIdentity> Autheticate(IdentityUser user, IEnumerable<Claim> principal) //генерация куки на основе утверждений о пользователе (claims);это происходит при входе в систему; метод принимает пользователя и его утверждения из БД//
        {
            var claims = principal.ToList();
            var role = await _userManager.GetRolesAsync(user);
            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName));
            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role[0]));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
