namespace Challenge.Data
{
    using Challenge.Shared.DBModels;
    using Challenge.Shared.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ChallengeContext : IdentityDbContext
    {
        public ChallengeContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Payment>                       Payments { get; set; }
        public DbSet<User>                          Users    { get; set; }
        public DbSet<UserPaymentValidationHistory>  UserPaymentValidationHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserPaymentValidationHistory>()                
                .HasKey(_ => new { _.PaymentId, _.UserId });
        }
    }
}