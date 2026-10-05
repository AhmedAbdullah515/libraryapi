using LibrarySystem.App_Context;
using LibrarySystem.Models;
using LibrarySystem.Repo.Interface;

namespace LibrarySystem.Repo.Implmentation
{
    public class BookRepo:GenaricRepo<Book>,IBook
    {
        public BookRepo(AppDbContext Context) : base(Context)
        {
        }

        public IEnumerable<Book> GetBooksByKeyWord(string KeyWord)
        {
            var resultBook = _context.Books.Where(a => a.Title.Contains(KeyWord.ToLower()) || a.Author.Contains(KeyWord.ToLower())).OrderBy(a => a.Title).ToList();
            return resultBook;
        }
        public Book GetBookByHighstPrice()
        {
            var book = _context.Books.OrderByDescending(a => a.Price).FirstOrDefault();
            return book;
        }


    }
}
