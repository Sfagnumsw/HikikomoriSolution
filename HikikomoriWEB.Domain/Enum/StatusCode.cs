using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikikomoriWEB.Domain.Enum
{
    public enum StatusCode //статус код ответа от сервисов при работе с репозиториями
    {
        OK = 200,
        NotFound = 404,
        ServerError = 500,
        UserExists = 409,
        Prohibited = 403,
    }
}
