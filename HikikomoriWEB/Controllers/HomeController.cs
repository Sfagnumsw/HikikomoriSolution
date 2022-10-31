using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Services.HelperMethods;
using HikikomoriWEB.Domain.ViewModels;

namespace HikikomoriWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseContentServices<RateContent,RateContentViewModel> _rateService;
        private readonly IBaseContentServices<RememberContent,RememberContentViewModel> _rememberService;

        public HomeController(IBaseContentServices<RateContent, RateContentViewModel> rate, IBaseContentServices<RememberContent, RememberContentViewModel> remember)
        {
            _rateService = rate;
            _rememberService = remember;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = ControllerAssistant.SelectListCategories();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> RateFormPost(RateContentViewModel obj)
        {
            var response = await _rateService.SaveContent(obj);
            return Content(response.Description);
        }

        [HttpPost]
        public async Task<ContentResult> RememberFormPost(RememberContentViewModel obj)
        {
            var response = await _rememberService.SaveContent(obj);
            return Content(response.Description);
        }
    }
}