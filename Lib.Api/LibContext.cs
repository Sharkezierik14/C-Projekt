using Contracts;
namespace Lib.Api
{
    using Microsoft.EntityFrameworkCore;

    public class LibContext : DbContext
    {
        public LibContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Member)
                .WithMany()
                .HasForeignKey(r => r.MemberId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId);
        }
    }
}