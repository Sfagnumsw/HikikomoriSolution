using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Services.HelperMethods;

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

            return View();
        }

        // Форма оценивания контента
        [HttpGet]
        public IActionResult NewRate()
        {
            ViewBag.Categories = ControllerAssistant.SelectListCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRate(RateContent obj)
        {
            var response = await _rateService.SaveContent(obj);
            if (response.ErrorCheck<RateContent>())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        //Форма отложенного контента
        [HttpGet]
        public IActionResult NewRemember()
        {
            ViewBag.Categories = ControllerAssistant.SelectListCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRemember(RememberContent obj)
        {
            var response = await _rememberService.SaveContent(obj);
            if (response.ErrorCheck<RememberContent>())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}