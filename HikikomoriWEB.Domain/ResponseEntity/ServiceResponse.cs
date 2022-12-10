using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ServiceResponse<T> : ServiceResponseBase //модель ответа, если от репозитория приходят данные
    {
        public T Data { get; set; } // полученные данные от репозитория 

        public ServiceResponse(StatusCode statusCode) : base(statusCode) { }
        public ServiceResponse(string description, StatusCode statusCode) : base(description, statusCode) { }
        public ServiceResponse(StatusCode statusCode, T data) : base(statusCode) { Data = data; }
        public ServiceResponse(string description, StatusCode statusCode, T data) : base(description, statusCode) { Data = data; }
    }
}
