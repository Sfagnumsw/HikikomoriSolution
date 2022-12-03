using HikikomoriWEB.DAL.Context;
using HikikomoriWEB.DAL.Interfaces;
using HikikomoriWEB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.DAL.EFRepositories
{
    public class RememberContentRepository : IBaseContentRepository<RememberContent> //репозиторий отложенного контента
    {
        private readonly HikDbContext _context;
        public RememberContentRepository(HikDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RememberContent>> GetAll() => await _context.RememberContent.ToListAsync();

        public async Task Delete(int ContentId)
        {
            var local = _context.Set<RememberContent>().Local.FirstOrDefault(i => i.Id.Equals(ContentId));
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.RememberContent.Remove(new RememberContent() { Id = ContentId });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RememberContent>> GetOnCategoryId(Categories category, string userId)
        {
            return await _context.RememberContent.Where(i => i.CategoryId == category && i.UserId == userId).ToListAsync();
        }

        public async Task<RememberContent> GetOnId(int ContentId)
        {
            return await _context.RememberContent.FirstOrDefaultAsync(i => i.Id == ContentId);
        }

        public async Task Save(RememberContent obj)
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
