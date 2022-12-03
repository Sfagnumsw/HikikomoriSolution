using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ServiceResponse<T> : ServiceResponseEmpty //модель ответа, если от репозитория приходят данные
    {
        public T Data { get; set; } // полученные данные от репозитория 
    }
}
