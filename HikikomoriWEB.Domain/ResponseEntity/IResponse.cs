using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public interface IResponse //модель ответа от сервисов или передачи на фронт ответа о состоянии запроса
    {
        public string Description { get; set; } //сообщение
        public StatusCode StatusCode { get; set; } //статус код
    }
}
