using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;
using HikikomoriWEB.Services.HelperMethods;

namespace HikikomoriWEB.Controllers
{
    public class ContentController : Controller
    {
        private readonly IBaseContentServices<RateContent> _rateService;
        private readonly IBaseContentServices<RememberContent> _rememberService;

        public ContentController(IBaseContentServices<RateContent> rate, IBaseContentServices<RememberContent> remember)
        {
            _rateService = rate;
            _rememberService = remember;
        }

        #region Заполнение таблиц
        public async Task<IActionResult> FilmList()
        {
            var rateResponse = await _rateService.GetFilms();
            var rememberResponse = await _rememberService.GetFilms();
            if(ControllerAssistant.ErrorCheck<RateContent, RememberContent>(rateResponse, rememberResponse))
            {
                return RedirectToAction("Error");
            }
            return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        public async Task<IActionResult> BookList()
        {
            var rateResponse = await _rateService.GetBooks();
            var rememberResponse = await _rememberService.GetBooks();
            if (ControllerAssistant.ErrorCheck<RateContent, RememberContent>(rateResponse, rememberResponse))
            {
                return RedirectToAction("Error");
            }
            return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        public async Task<IActionResult> GameList()
        {
            var rateResponse = await _rateService.GetGames();
            var rememberResponse = await _rememberService.GetGames();
            if (ControllerAssistant.ErrorCheck<RateContent, RememberContent>(rateResponse, rememberResponse))
            {
                return RedirectToAction("Error");
            }
            return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        public async Task<IActionResult> SerialList()
        {
            var rateResponse = await _rateService.GetSerials();
            var rememberResponse = await _rememberService.GetSerials();
            if (ControllerAssistant.ErrorCheck<RateContent, RememberContent>(rateResponse, rememberResponse))
            {
                return RedirectToAction("Error");
            }
            return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }

        public async Task<IActionResult> CartoonList()
        {
            var rateResponse = await _rateService.GetCartoons();
            var rememberResponse = await _rememberService.GetCartoons();
            if (ControllerAssistant.ErrorCheck<RateContent, RememberContent>(rateResponse, rememberResponse))
            {
                return RedirectToAction("Error");
            }
            return View(new ContentListViewModel(rateResponse.Data, rememberResponse.Data));
        }
        #endregion

        public async Task<IActionResult> RemoveAction(int Id, string tableClass)
        {
            if(Id != 0 && tableClass != null)
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
