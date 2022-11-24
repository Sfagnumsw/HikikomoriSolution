using HikikomoriWEB.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.ResponseEntity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IBaseContentServices<K>
        where K : AbstractContentViewModel
    {
        Task<ServiceResponseEmpty> SaveContent(K obj);
        Task<ServiceResponseEmpty> DeleteContent(int ContentId);
        Task<ServiceResponse<IEnumerable<K>>> GetFilms();
        Task<ServiceResponse<IEnumerable<K>>> GetBooks();
        Task<ServiceResponse<IEnumerable<K>>> GetGames();
        Task<ServiceResponse<IEnumerable<K>>> GetSerials();
        Task<ServiceResponse<IEnumerable<K>>> GetCartoons();
    }
}
