using System.Collections.Generic;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class ContentListViewModel //модель данных для передачи в представление с отображением контента
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
