using HikikomoriWEB.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface IBaseContentServices<T> //прослойка бизнес логики между уровнем DAL и Таргетным проектом HikikomoriWEB
    {
        Task<IResponseRepository<IEnumerable<T>>> AllContent();
        Task<IResponseRepository<T>> GetOnId(int ContentId);
        Task<IResponseRepository<T>> SaveContent(T obj);
        Task<IResponseRepository<T>> DeleteContent(int ContentId);
        Task<IResponseRepository<IEnumerable<T>>> GetOnCategoryId(int CategoryId);
    }
}
