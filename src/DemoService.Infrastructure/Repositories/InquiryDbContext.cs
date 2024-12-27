using DemoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoService.Infrastructure.Repositories
{
    public class InquiryDbContext : DbContext
    {
        public InquiryDbContext(DbContextOptions<InquiryDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define one-to-many relationship between ApiKey and User
            modelBuilder.Entity<ApiKey>()
                .HasMany(a => a.Users)  // An ApiKey has many Users
                .WithOne(u => u.ApiKey) // Each User has one ApiKey
                .HasForeignKey(u => u.ApiKeyId);  // Foreign key in User table that links to ApiKey

            base.OnModelCreating(modelBuilder);
        }
    }
}
