using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Domain.ViewModels;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.ResponseEntity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace HikikomoriWEB.Controllers
{
    public class AccountController : Controller //контроллер управления пользователями
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService service)
        {
            _accountService = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> Login(SignInViewModel model)
        {
            var response = await _accountService.SignIn(model);
            var jsonObj = JsonConvert.SerializeObject(response);
            return Json(jsonObj);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Registration(RegistrationViewModel model)
        {
            var response = await _accountService.CreateUser(model);
            var jsonObj = JsonConvert.SerializeObject(response);
            return Json(jsonObj);
        }

        public async Task<IActionResult> Logout()
        {
            var response = await _accountService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetUserData()
        {
            var response = await _accountService.GetUserData();
            return View(response.Data);
        }
    }
}
