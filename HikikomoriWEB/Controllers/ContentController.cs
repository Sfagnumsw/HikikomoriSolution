using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using HikikomoriWEB.Services.HelperMethods;
using System.Collections.Generic;
using HikikomoriWEB.Domain.ResponseEntity;
using Microsoft.AspNetCore.Authorization;

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
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
            var rateResponse = await _rateService.GetBooks();
            var rememberResponse = await _rememberService.GetBooks();
            return View("ContentList",  new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetSerials()
        {
            var rateResponse = await _rateService.GetSerials();
            var rememberResponse = await _rememberService.GetSerials();
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetCartoons()
        {
            var rateResponse = await _rateService.GetCartoons();
            var rememberResponse = await _rememberService.GetCartoons();
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
        public async Task<IActionResult> GetGames()
        {
            var rateResponse = await _rateService.GetGames();
            var rememberResponse = await _rememberService.GetGames();
            return View("ContentList", new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        [Authorize]
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
