using HikikomoriWEB.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IBaseContentServices<T> //прослойка бизнес логики между уровнем DAL и Таргетным проектом HikikomoriWEB
    {
        Task<IResponseRepository<T>> SaveContent(T obj);
        Task<IResponseRepository<T>> DeleteContent(int ContentId);
        Task<IResponseRepository<T>> GetOnId(int ContentId);
        Task<IResponseRepository<IEnumerable<T>>> GetFilms();
        Task<IResponseRepository<IEnumerable<T>>> GetBooks();
        Task<IResponseRepository<IEnumerable<T>>> GetGames();
        Task<IResponseRepository<IEnumerable<T>>> GetSerials();
        Task<IResponseRepository<IEnumerable<T>>> GetCartoons();
    }
}
