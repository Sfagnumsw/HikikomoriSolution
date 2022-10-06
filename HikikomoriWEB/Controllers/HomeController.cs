using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Services.HelperMethods;
using HikikomoriWEB.Services.RequestServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        public async Task<IActionResult> Index()
        {
            var Quote = await QuotesApiRequest.Quote();
            return View(Quote);
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
            if(ModelState.IsValid)
            {
                var response = await _rateService.SaveContent(obj);
                if(ControllerAssistant.ErrorCheck<RateContent>(response))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            return View();
        }
        
        //Форма отложенного контента
        [HttpGet]
        public  IActionResult NewRemember()
        {
            ViewBag.Categories = ControllerAssistant.SelectListCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRemember(RememberContent obj)
        {
            if (ModelState.IsValid)
            {
                var response = await _rememberService.SaveContent(obj);
                if(ControllerAssistant.ErrorCheck<RememberContent>(response))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            return View();
        }
    }
}
