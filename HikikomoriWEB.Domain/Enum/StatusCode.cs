
namespace HikikomoriWEB.Domain.Enum
{
    public enum StatusCode //статус код ответа от сервисов при работе с репозиториями
    {
        Null = 0,
        OK = 200,
        NotFound = 404,
        ServerError = 500,
        UserExists = 409,
        Prohibited = 403,
    }
}
