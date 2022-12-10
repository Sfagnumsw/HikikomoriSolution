using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ServiceResponseBase
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public ServiceResponseBase(StatusCode statusCode) { StatusCode = statusCode; }
        public ServiceResponseBase(string description, StatusCode statusCode)
        {
            Description = description;
            StatusCode = statusCode;
        }
    }
}
