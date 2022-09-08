using HikikomoriWEB.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.DAL.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;

namespace HikikomoriWEB.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IResponseRepository<IEnumerable<Categories>>> AllCategories();
        Task<IResponseRepository<Categories>> GetOnId(int CategoryId);
    }
}
