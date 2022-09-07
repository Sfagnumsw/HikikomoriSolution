using HikikomoriWEB.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HikikomoriWEB.DAL.Interfaces
{
    interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> AllCategories();
        Task<Categories> GetOnId(int Categoryid);
    }
}
