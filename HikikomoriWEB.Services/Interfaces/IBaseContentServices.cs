using HikikomoriWEB.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.ResponseEntity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IBaseContentServices<K> //сервис бизнес логики контента
        where K : AbstractContentViewModel
    {
        Task<ServiceResponseEmpty> SaveContent(K obj); //сохранить
        Task<ServiceResponseEmpty> DeleteContent(int ContentId); //удалить
        Task<ServiceResponse<IEnumerable<K>>> GetFilms(); //получить контент конкретной категории
        Task<ServiceResponse<IEnumerable<K>>> GetBooks();
        Task<ServiceResponse<IEnumerable<K>>> GetGames();
        Task<ServiceResponse<IEnumerable<K>>> GetSerials();
        Task<ServiceResponse<IEnumerable<K>>> GetCartoons();
    }
}
