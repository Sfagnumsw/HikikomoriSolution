using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Domain.Entity
{
    public class RateContent : AbstractContent
    {
        [Display(Name = "Флаг пересмотра")]
        public bool Replay { get; set; }

        [Display(Name = "Оценка")]
        public int Rating { get; set; }
    }
}
