using System.Collections.Generic;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.DAL.Context;
using HikikomoriWEB.DAL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HikikomoriWEB.DAL.EFRepositories
{
    class CategoriesRepository : ICategoriesRepository
    {
        private readonly HikDbContext _context;
        public CategoriesRepository(HikDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> AllCategories() => await _context.Categories.ToListAsync();

        public async Task<Categories> GetOnId(int Categoryid)
        {
            return await _context.Categories.FirstOrDefaultAsync(i => i.Id == Categoryid);
        }
    }
}
