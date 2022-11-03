using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.ViewModels;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ResponseRepository<T>                        //модель статуса ответа от репозитория
    {
        public string Description { get; set; } //описание
        public StatusCode StatusCode { get; set; } //статус код
        public T Data { get; set; } //данные
    }
}
