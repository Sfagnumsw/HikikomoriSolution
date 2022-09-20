using HikikomoriWEB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HikikomoriWEB.DAL.Context
{
    public class HikDbContext : DbContext //контекст быза данных EF
    {
        public HikDbContext(DbContextOptions<HikDbContext> options) : base(options) { }
        public DbSet<RateContent> RateContent { get; set; } //таблицы
        public DbSet<RememberContent> RememberContent { get; set; }
        public DbSet<UsersDataAutorisation> UsersData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
