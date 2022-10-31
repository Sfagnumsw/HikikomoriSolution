using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikikomoriWEB.Domain.ResponseEntity
{
    public class ResponseRepository<T> : IResponseRepository<T> //наследование от интерефейса необязательно(но соответсвует парадигме)
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
