using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.ResponseEntity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IBaseContentServices<K>
        where K : AbstractContentViewModel
    {
        Task<ResponseRepository<K>> SaveContent(K obj);
        Task<ResponseRepository<K>> DeleteContent(int ContentId);
        Task<ResponseRepository<IEnumerable<K>>> GetFilms();
        Task<ResponseRepository<IEnumerable<K>>> GetBooks();
        Task<ResponseRepository<IEnumerable<K>>> GetGames();
        Task<ResponseRepository<IEnumerable<K>>> GetSerials();
        Task<ResponseRepository<IEnumerable<K>>> GetCartoons();
    }
}
