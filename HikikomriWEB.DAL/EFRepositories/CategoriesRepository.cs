using HikikomoriWEB.Domain.Entity;
using HikikomriWEB.DAL.Context;
using HikikomriWEB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HikikomriWEB.DAL.EFRepositories
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
