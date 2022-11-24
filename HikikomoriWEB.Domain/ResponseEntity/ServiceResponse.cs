using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ServiceResponse<T> : ServiceResponseEmpty               //модель статуса ответа от репозитория
    {
        public T Data { get; set; } // полученные данные от репозитория 
    }
}
