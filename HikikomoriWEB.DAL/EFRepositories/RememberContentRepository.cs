using HikikomoriWEB.DAL.Context;
using HikikomoriWEB.DAL.Interfaces;
using HikikomoriWEB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikikomoriWEB.DAL.EFRepositories
{
    class RememberContentRepository : IBaseContentRepository<RememberContent>
    {
        private readonly HikDbContext _context;
        public RememberContentRepository(HikDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RememberContent>> AllContent() => await _context.RememberContent.ToListAsync();

        public async Task DeleteContent(int ContentId)
        {
            _context.RememberContent.Remove(new RememberContent { Id = ContentId });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RememberContent>> GetOnCategoryId(int CategoryId)
        {
            return await _context.RememberContent.Where(i => i.CategoryId == CategoryId).ToListAsync();
        }

        public async Task<RememberContent> GetOnId(int ContentId)
        {
            return await _context.RememberContent.FirstOrDefaultAsync(i => i.Id == ContentId);
        }

        public async Task SaveContent(RememberContent obj)
        {
            if (obj.Id == default)
            {
                _context.Entry(obj).State = EntityState.Added;
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
    }
}
