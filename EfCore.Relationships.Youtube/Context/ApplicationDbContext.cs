using EfCore.Relationships.Youtube.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Relationships.Youtube.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasOne(p => p.UserInformationId)
        }
    }
}
