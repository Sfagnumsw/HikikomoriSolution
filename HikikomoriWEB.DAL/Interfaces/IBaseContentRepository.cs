using System.Collections.Generic;
using System.Threading.Tasks;

namespace HikikomoriWEB.DAL.Interfaces
{
    public interface IBaseContentRepository<T>
    {
        Task<IEnumerable<T>> AllContent(); //получить контент
        Task<T> GetOnId(int ContentId); //контент по ID
        Task SaveContent(T obj); //сохранить
        Task DeleteContent(int ContentId); //удалить
        Task<IEnumerable<T>> GetOnCategoryId(int CategoryId); // получить весь контент из определенной категории
    }
}
