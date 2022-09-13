using Microsoft.AspNetCore.Mvc;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using System.Threading.Tasks;


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

        public async Task<IActionResult> FilmList()
        {
            var rateResponse = await _rateService.GetFilms();
            var rememberResponse = await _rememberService.GetFilms();
            if(rateResponse.StatusCode == Domain.Enum.StatusCode.ServerError || rememberResponse.StatusCode == Domain.Enum.StatusCode.ServerError)
            {
                return RedirectToAction("Error");
            }
            
            ViewBag.Rated = rateResponse.Data;
            ViewBag.Remembered = rememberResponse.Data;
            return View();
        }

        public async Task<IActionResult> BookList()
        {
            var rateResponse = await _rateService.GetBooks();
            var rememberResponse = await _rememberService.GetBooks();
            if (rateResponse.StatusCode == Domain.Enum.StatusCode.ServerError || rememberResponse.StatusCode == Domain.Enum.StatusCode.ServerError)
            {
                return RedirectToAction("Error");
            }

            ViewBag.Rated = rateResponse.Data;
            ViewBag.Remembered = rememberResponse.Data;
            return View();
        }

        public async Task<IActionResult> GameList()
        {
            var rateResponse = await _rateService.GetGames();
            var rememberResponse = await _rememberService.GetGames();
            if (rateResponse.StatusCode == Domain.Enum.StatusCode.ServerError || rememberResponse.StatusCode == Domain.Enum.StatusCode.ServerError)
            {
                return RedirectToAction("Error");
            }

            ViewBag.Rated = rateResponse.Data;
            ViewBag.Remembered = rememberResponse.Data;
            return View();
        }

        public async Task<IActionResult> SerialList()
        {
            var rateResponse = await _rateService.GetSerials();
            var rememberResponse = await _rememberService.GetSerials();
            if (rateResponse.StatusCode == Domain.Enum.StatusCode.ServerError || rememberResponse.StatusCode == Domain.Enum.StatusCode.ServerError)
            {
                return RedirectToAction("Error");
            }

            ViewBag.Rated = rateResponse.Data;
            ViewBag.Remembered = rememberResponse.Data;
            return View();
        }

        public async Task<IActionResult> CartoonList()
        {
            var rateResponse = await _rateService.GetCartoons();
            var rememberResponse = await _rememberService.GetCartoons();
            if (rateResponse.StatusCode == Domain.Enum.StatusCode.ServerError || rememberResponse.StatusCode == Domain.Enum.StatusCode.ServerError)
            {
                return RedirectToAction("Error");
            }

            ViewBag.Rated = rateResponse.Data;
            ViewBag.Remembered = rememberResponse.Data;
            return View();
        }
    }
}
