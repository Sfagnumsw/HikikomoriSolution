using HikikomoriWEB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class ErrorViewModel
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
