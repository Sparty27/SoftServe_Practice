using Microsoft.EntityFrameworkCore;
using SoftServe_Practice.Models;

namespace SoftServe_Practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }
        public DbSet<SessionTicketPrice> SessionTicketPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SessionTicketPrice>()
                .HasKey(stp => new { stp.SessionId, stp.TicketPriceId });

            modelBuilder.Entity<SessionTicketPrice>()
                .HasOne(stp => stp.Session)
                .WithMany(s => s.SessionTicketPrices)
                .HasForeignKey(stp => stp.SessionId);

            modelBuilder.Entity<SessionTicketPrice>()
                .HasOne(stp => stp.TicketPrice)
                .WithMany(tp => tp.SessionTicketPrices)
                .HasForeignKey(stp => stp.TicketPriceId);
        }
    }
}
