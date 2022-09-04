using HikikomoriWEB.Domain.Entity;
using HikikomriWEB.DAL.Context;
using HikikomriWEB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikikomriWEB.DAL.EFRepositories
{
    public class RateContentRepository : IContentRepository<RateContent>
    {
        private readonly HikDbContext _context;
        public RateContentRepository(HikDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RateContent>> AllContent() => await _context.RateContent.ToListAsync();

        public async Task DeleteContent(int ContentId)
        {
            _context.RateContent.Remove(new RateContent() { Id = ContentId });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RateContent>> GetOnCategoryId(int CategoryId)
        {
            return await _context.RateContent.Where(i => i.CategoryId == CategoryId).ToListAsync();
        }

        public async Task<RateContent> GetOnId(int ContentId)
        {
            return await _context.RateContent.FirstOrDefaultAsync(i => i.Id == ContentId);
        }

        public async Task SaveContent(RateContent obj)
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
