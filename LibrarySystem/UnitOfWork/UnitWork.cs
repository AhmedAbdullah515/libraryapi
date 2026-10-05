using LibrarySystem.App_Context;
using LibrarySystem.Models;
using LibrarySystem.Repo.Interface;

namespace LibrarySystem.UnitOfWork
{
    public class UnitWork:IUnitWork
    {
        public IBook Bookrepo { get; }
        public IGenariceRepo<Category> Categoryrepeo { get; }
        public IGenariceRepo<Member> Memberrepo { get; }
        public IGenariceRepo<Borrowing> Borrowingrepo { get; }
        private readonly AppDbContext _context;
        public UnitWork(AppDbContext context,IBook book,IGenariceRepo<Category>category,IGenariceRepo<Member>member,IGenariceRepo<Borrowing>borrowing)
        {
            _context = context;
            Bookrepo = book;
            Categoryrepeo = category;
            Memberrepo = member;
            Borrowingrepo = borrowing;
              

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
