using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Services.HelperMethods;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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

        [HttpGet]
        public IActionResult NewRate()
        {
            ViewBag.Categories = Helpers.SelectListCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRate(RateContent obj)
        {
            if(ModelState.IsValid)
            {
                await _rateService.SaveContent(obj);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public  IActionResult NewRemember()
        {
            ViewBag.Categories = Helpers.SelectListCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRemember(RememberContent obj)
        {
            if (ModelState.IsValid)
            {
                await _rememberService.SaveContent(obj);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
