using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ServiceResponseEmpty : IResponse
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
