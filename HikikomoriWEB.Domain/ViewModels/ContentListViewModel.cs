using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.Domain.Entity;
using System.Threading.Tasks;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class ContentListViewModel //список всего контента для передачи в представление
    {
        public IEnumerable<RateContentViewModel> RatedList { get; set; }
        public IEnumerable<RememberContentViewModel> RememberedList { get; set; }

        public ContentListViewModel(IEnumerable<RateContentViewModel> rated, IEnumerable<RememberContentViewModel> remembered)
        {
            RatedList = rated;
            RememberedList = remembered;
        }
    }
}
