using LibrarySystem.Models;

namespace LibrarySystem.Repo.Interface
{
    public interface IBook:IGenariceRepo<Book>
    {
        public IEnumerable<Book> GetBooksByKeyWord(string KeyWord);
        public Book GetBookByHighstPrice();
    }
}
