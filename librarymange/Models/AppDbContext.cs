using librarymange.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace librarymange.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(br => br.Records)
                .WithOne(b => b.Book)
                .HasForeignKey(fk => fk.BookID);

            modelBuilder.Entity<Member>()
                .HasMany(br => br.Records)
                .WithOne(m => m.Member)
                .HasForeignKey(fk => fk.MemberID);
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Member> Members { get; set;}
        public DbSet<BookRecord> BookRecords { get; set;}
    }
}
