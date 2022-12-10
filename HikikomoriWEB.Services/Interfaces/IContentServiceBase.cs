using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.ViewModels;
using System.Threading.Tasks;

namespace HikikomoriWEB.Services.Interfaces
{
     public interface IContentServiceBase<T> where T : AbstractContentViewModel
    {
        Task<ServiceResponseBase> SaveContent(T obj); //сохранить
        Task<ServiceResponseBase> DeleteContent(int ContentId); //удалить
     }
}
