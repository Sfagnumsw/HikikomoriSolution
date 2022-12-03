using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Services.HelperMethods;
using HikikomoriWEB.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace HikikomoriWEB.Controllers
{
    public class HomeController : Controller //контроллер главной страницы
    {
        private readonly IBaseContentServices<RateContentViewModel> _rateService;
        private readonly IBaseContentServices<RememberContentViewModel> _rememberService;

        public HomeController(IBaseContentServices<RateContentViewModel> rate, IBaseContentServices<RememberContentViewModel> remember)
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
        public async Task<ContentResult> RateFormPost(RateContentViewModel obj)
        {
            var response = await _rateService.SaveContent(obj);
            return Content(response.Description);
        }

        [Authorize]
        [HttpPost]
        public async Task<ContentResult> RememberFormPost(RememberContentViewModel obj)
        {
            var response = await _rememberService.SaveContent(obj);
            return Content(response.Description);
        }
    }
}