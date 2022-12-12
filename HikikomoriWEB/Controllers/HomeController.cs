using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Services.HelperMethods;
using HikikomoriWEB.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace HikikomoriWEB.Controllers
{
    public class HomeController : Controller //контроллер главной страницы
    {
        private readonly IContentServices<RateContentViewModel> _rateService;
        private readonly IContentServices<RememberContentViewModel> _rememberService;

        public HomeController(IContentServices<RateContentViewModel> rate, IContentServices<RememberContentViewModel> remember)
        {
            _rateService = rate;
            _rememberService = remember;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = ControllerAssistant.SelectListCategories();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> RateFormPost(RateContentViewModel obj)
        {
            var response = await _rateService.SaveContent(obj);
            return Json(JsonConvert.SerializeObject(response));
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> RememberFormPost(RememberContentViewModel obj)
        {
            var response = await _rememberService.SaveContent(obj);
            return Json(JsonConvert.SerializeObject(response));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}