using Authentication_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Api.Data
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}