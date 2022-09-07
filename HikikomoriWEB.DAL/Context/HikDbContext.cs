using HikikomoriWEB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HikikomoriWEB.DAL.Context
{
    public class HikDbContext : DbContext //контекст быза данных EF
    {
        public HikDbContext(DbContextOptions<HikDbContext> options) : base(options) { }

        public DbSet<RateContent> RateContent { get; set; } //таблицы
        public DbSet<RememberContent> RememberContent { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<UsersDataAutorisation> UsersData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // заполнение таблицы при создании
        {
            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                Id = 10000,
                Category = "Фильмы"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                Id = 10001,
                Category = "Книги"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                Id = 10002,
                Category = "Игры"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                Id = 10003,
                Category = "Сериалы"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                Id = 10004,
                Category = "Мультфильмы"
            });
        }
    }
}
