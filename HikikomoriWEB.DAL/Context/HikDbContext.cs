using HikikomoriWEB.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HikikomoriWEB.DAL.Context
{
    public class HikDbContext : IdentityDbContext<IdentityUser> //контекст бызы данных для EF, принимает стандартный тип пользователя IdentityUser
    {
        public HikDbContext(DbContextOptions<HikDbContext> options) : base(options) { }
        public DbSet<RateContent> RateContent { get; set; } //таблицы
        public DbSet<RememberContent> RememberContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RateContent>().HasIndex(i => new { i.UserId, i.CategoryId }).HasDatabaseName("RateContentUserIndex");
            modelBuilder.Entity<RememberContent>().HasIndex(i => new { i.UserId, i.CategoryId }).HasDatabaseName("RememberContentUserIndex");

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2",
                Name = "user",
                NormalizedName = "USER"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "3",
                Name = "moder",
                NormalizedName = "MODER"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "cccd8a1d-d3ec-4dfe-84b4-b6488b2565cc",
                UserName = "sfagnumX",
                Email = "swimming1999@mail.ru",
                NormalizedUserName = "SFAGNUMX",
                NormalizedEmail = "SWIMMING1999@MAIL.RU",
                PasswordHash = new PasswordHasher<IdentityUser<int>>().HashPassword(null, "Qwerty12345"),
                SecurityStamp = string.Empty,
                EmailConfirmed = true
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "cccd8a1d-d3ec-4dfe-84b4-b6488b2565cc"
            });
        }
    }
}
