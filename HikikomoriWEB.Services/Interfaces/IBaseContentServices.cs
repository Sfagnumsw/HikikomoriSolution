using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.Interfaces;
using HikikomoriWEB.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IBaseContentServices<T,K>
        where T : AbstractContent
        where K : AbstractContentViewModel
    {
        Task<IResponseRepository<T>> SaveContent(K obj);
        Task<IResponseRepository<T>> DeleteContent(int ContentId);
        Task<IResponseRepository<T>> GetOnId(int ContentId);
        Task<IResponseRepository<IEnumerable<T>>> GetFilms();
        Task<IResponseRepository<IEnumerable<T>>> GetBooks();
        Task<IResponseRepository<IEnumerable<T>>> GetGames();
        Task<IResponseRepository<IEnumerable<T>>> GetSerials();
        Task<IResponseRepository<IEnumerable<T>>> GetCartoons();
    }
}
