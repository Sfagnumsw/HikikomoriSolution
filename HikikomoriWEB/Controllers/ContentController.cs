using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using HikikomoriWEB.Services.HelperMethods;
using System.Collections.Generic;
using HikikomoriWEB.Domain.ResponseEntity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace HikikomoriWEB.Controllers
{
    [Authorize]
    public class ContentController : Controller //контроллер для отображения контента
    {
        private readonly IContentServices<RateContentViewModel> _rateService;
        private readonly IContentServices<RememberContentViewModel> _rememberService;

        public ContentController(IContentServices<RateContentViewModel> rate, IContentServices<RememberContentViewModel> remember)
        {
            _rateService = rate;
            _rememberService = remember;
        }

        [Authorize]
        public async Task<IActionResult> GetFilms()
        {
            var rateResponse = await _rateService.GetFilms();
            var rememberResponse = await _rememberService.GetFilms();
            if (!rateResponse.CheckServerError() || !rememberResponse.CheckServerError()) return RedirectToAction("Error", "Home");
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
            var rateResponse = await _rateService.GetBooks();
            var rememberResponse = await _rememberService.GetBooks();
            if (!rateResponse.CheckServerError() || !rememberResponse.CheckServerError()) return RedirectToAction("Error", "Home");
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetSerials()
        {
            var rateResponse = await _rateService.GetSerials();
            var rememberResponse = await _rememberService.GetSerials();
            if (!rateResponse.CheckServerError() || !rememberResponse.CheckServerError()) return RedirectToAction("Error", "Home");
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetCartoons()
        {
            var rateResponse = await _rateService.GetCartoons();
            var rememberResponse = await _rememberService.GetCartoons();
            if (!rateResponse.CheckServerError() || !rememberResponse.CheckServerError()) return RedirectToAction("Error", "Home");
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetGames()
        {
            var rateResponse = await _rateService.GetGames();
            var rememberResponse = await _rememberService.GetGames();
            if (!rateResponse.CheckServerError() || !rememberResponse.CheckServerError()) return RedirectToAction("Error", "Home");
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<JsonResult> RemoveAction(int Id, string tableClass) //удаление строки таблицы(удаление контента из БД)
        {
            if (tableClass.Equals("table-list-rate"))
            {
                var response = await _rateService.DeleteContent(Id);
                return Json(JsonConvert.SerializeObject(response));
            }
            else if (tableClass.Equals("table-list-remember"))
            {
                var response = await _rememberService.DeleteContent(Id);
                return Json(JsonConvert.SerializeObject(response));
            }
            else return Json(JsonConvert.SerializeObject(new ServiceResponseBase("Выберите строку для удаления", Domain.Enum.StatusCode.OK)));
        }
    }
}
