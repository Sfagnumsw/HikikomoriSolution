using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.Domain.Entity;
using System.Threading.Tasks;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class ContentListViewModel
    {
        public IEnumerable<RateContent> RatedList { get; set; }
        public IEnumerable<RememberContent> RememberedList { get; set; }

        public ContentListViewModel(IEnumerable<RateContent> rated, IEnumerable<RememberContent> remembered)
        {
            RatedList = rated;
            RememberedList = remembered;
        }
    }
}
