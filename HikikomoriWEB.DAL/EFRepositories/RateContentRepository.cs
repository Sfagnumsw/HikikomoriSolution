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
    public class RateContentRepository : IBaseContentRepository<RateContent> //репозиторий оцененного контента
    {
        private readonly HikDbContext _context;
        public RateContentRepository(HikDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RateContent>> GetAll() => await _context.RateContent.ToListAsync();

        public async Task Delete(int ContentId)
        {
            var local = _context.Set<RateContent>().Local.FirstOrDefault(i => i.Id.Equals(ContentId));
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.RateContent.Remove(new RateContent() { Id = ContentId });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RateContent>> GetOnCategoryId(Categories category, string userId)
        {
            return await _context.RateContent.Where(i => i.CategoryId == category && i.UserId == userId).ToListAsync();
        }

        public async Task<RateContent> GetOnId(int ContentId)
        {
            return await _context.RateContent.FirstOrDefaultAsync(i => i.Id == ContentId);
        }

        public async Task Save(RateContent obj)
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
