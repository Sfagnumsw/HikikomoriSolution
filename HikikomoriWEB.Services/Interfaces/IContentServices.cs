using HikikomoriWEB.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.ResponseEntity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IContentServices<T> : IContentServiceBase<T> //сервис бизнес логики контента
        where T : AbstractContentViewModel
    {
        Task<ServiceResponse<IEnumerable<T>>> GetFilms(); //получить контент конкретной категории
        Task<ServiceResponse<IEnumerable<T>>> GetBooks();
        Task<ServiceResponse<IEnumerable<T>>> GetGames();
        Task<ServiceResponse<IEnumerable<T>>> GetSerials();
        Task<ServiceResponse<IEnumerable<T>>> GetCartoons();
    }
}
