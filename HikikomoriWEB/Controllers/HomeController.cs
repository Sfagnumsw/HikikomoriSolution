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
        private readonly IBaseContentServices<RateContent> _rateService;
        private readonly IBaseContentServices<RememberContent> _rememberService;

        public HomeController(IBaseContentServices<RateContent> rate, IBaseContentServices<RememberContent> remember)
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
            //var response = await _rateService.SaveContent(obj);
            //return Content("asd");
        }

        [HttpPost]
        public ContentResult RememberFormPost(RememberContentViewModel obj)
        {

            //return Content("");
        }
    }
}