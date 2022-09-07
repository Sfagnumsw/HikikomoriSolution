using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.Interfaces
{
    public interface IResponseRepository<T> //модель ответа от репозитория
    {
        string Description { get; set; } //описание ошибки
        StatusCode StatusCode { get; set; } //статус код
        T Data { get; set; } //данные от методов репозитория
    }
}
