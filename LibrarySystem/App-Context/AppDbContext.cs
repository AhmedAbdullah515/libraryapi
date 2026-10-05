using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.App_Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>Options):base(Options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Attribute
            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(a => a.ISBN).IsUnique();
            modelBuilder.Entity<Book>().Property(a => a.IsAvailable).HasDefaultValue(true);
            modelBuilder.Entity<Member>().HasIndex(a => a.Email).IsUnique();
            //relations
            modelBuilder.Entity<Book>().HasOne(a => a.Category).WithMany(a => a.Books).HasForeignKey(a => a.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Borrowing>().HasOne(a => a.Member).WithMany(a => a.Borrowings).HasForeignKey(a => a.MemberId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Borrowing>().HasOne(a => a.Book).WithMany(a => a.Borrowings).HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Category>().HasData(
        new Category
        {
            CategoryId = 1,
            Name = "Programming",
            Description = "Programming and software development books"
        },
        new Category
        {
            CategoryId = 2,
            Name = "Database",
            Description = "Database and data management books"
        }
    );


            // =========================
            // Book Seed
            // =========================

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "C++ Basics",
                    Author = "John Smith",
                    ISBN = "ISBN001",
                    Price = 450,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "SQL Fundamentals",
                    Author = "Sarah Ali",
                    ISBN = "ISBN002",
                    Price = 500,
                    IsAvailable = false,
                    CategoryId = 2
                }
            );


            // =========================
            // Member Seed
            // =========================

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberId = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Phone = "01012345678"
                },
                new Member
                {
                    MemberId = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    Phone = "01198765432"
                }
            );


            // =========================
            // Borrowing Seed
            // =========================

            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing
                {
                    BorrowingId = 1,
                    BorrowDate = new DateTime(2026, 9, 20),
                    ReturnDate = new DateTime(2026, 9, 25),
                    MemberId = 1,
                    BookId = 1
                },
                new Borrowing
                {
                    BorrowingId = 2,
                    BorrowDate = new DateTime(2026, 9, 22),
                    ReturnDate = null,
                    MemberId = 2,
                    BookId = 2
                }
            );
        }
    }
}
