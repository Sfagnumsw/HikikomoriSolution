using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikikomoriWEB.Domain.ViewModels
{
    public class CategoryViewModel //модель данных категории для создания SelectList
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}
