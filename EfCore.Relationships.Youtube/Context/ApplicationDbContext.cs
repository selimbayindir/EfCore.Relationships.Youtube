using EfCore.Relationships.Youtube.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Relationships.Youtube.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public  DbSet<User> Users { get; set; }
        public  DbSet<UserInformation> UsersInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
          .HasOne(u => u.UserInformation)
          .WithOne()
          .HasForeignKey<User>(p => p.UserInformationId) // ForeignKey olarak UserId kullanılıyor
          .OnDelete(DeleteBehavior.NoAction); // İlişkili UserInformation verisi silindiğinde User da silinsin

        }
    }
}
