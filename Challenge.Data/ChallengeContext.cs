namespace Challenge.Data
{
    using Challenge.Shared.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Payment>                       Payments { get; set; }
        public DbSet<User>                          Users    { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}