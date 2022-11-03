using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using HikikomoriWEB.Services.HelperMethods;
using System.Collections.Generic;
using HikikomoriWEB.Domain.ResponseEntity;

namespace HikikomoriWEB.Controllers
{
    public class ContentController : Controller
    {
        private readonly IBaseContentServices<RateContentViewModel> _rateService;
        private readonly IBaseContentServices<RememberContentViewModel> _rememberService;

        public ContentController(IBaseContentServices<RateContentViewModel> rate, IBaseContentServices<RememberContentViewModel> remember)
        {
            _rateService = rate;
            _rememberService = remember;
        }

        public async Task<IActionResult> ContentList(string type) //таблицы с контентом
        {
            ResponseRepository<IEnumerable<RateContentViewModel>> rateResponse;
            ResponseRepository<IEnumerable<RememberContentViewModel>> rememberResponse;
            switch (type)
            {
                case "films":
                    rateResponse = await _rateService.GetFilms();
                    rememberResponse = await _rememberService.GetFilms();
                    return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
                case "books":
                    rateResponse = await _rateService.GetBooks();
                    rememberResponse = await _rememberService.GetBooks();
                    return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
                case "games":
                    rateResponse = await _rateService.GetGames();
                    rememberResponse = await _rememberService.GetGames();
                    return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
                case "serials":
                    rateResponse = await _rateService.GetSerials();
                    rememberResponse = await _rememberService.GetSerials();
                    return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
                case "cartoons":
                    rateResponse = await _rateService.GetCartoons();
                    rememberResponse = await _rememberService.GetCartoons();
                    return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
                default:
                    return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> RemoveAction(int Id, string tableClass) //удаление строки таблицы(удаление контента из БД)
        {
            if (Id != 0 && tableClass != null)
            {
                switch (tableClass)
                {
                    case "table-list-rate":
                        await _rateService.DeleteContent(Id);
                        break;
                    case "table-list-remember":
                        await _rememberService.DeleteContent(Id);
                        break;
                }
            }
            return NoContent();
        }
    }
}
