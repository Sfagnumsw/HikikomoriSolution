using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Domain.ViewModels;
using HikikomoriWEB.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace HikikomoriWEB.Controllers
{
    public class AccountController : Controller
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
        public async Task<ContentResult> Login(SignInViewModel model)
        {
            var response = await _accountService.SignIn(model);
            return Content(((int)response.StatusCode).ToString());
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
            var obj = new JsonDataAuthorizeViewModel()
            {
                Message = response.Description,
                Status = ((int)response.StatusCode).ToString()
            };
            string json = JsonConvert.SerializeObject(obj);
            return Json(json);
        }
    }
}
