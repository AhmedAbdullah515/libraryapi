using LibrarySystem.Models;
using LibrarySystem.Repo.Interface;

namespace LibrarySystem.UnitOfWork
{
    public interface IUnitWork
    {
        public IBook Bookrepo { get; }
        public IGenariceRepo<Category> Categoryrepeo { get; }
        public IGenariceRepo<Member> Memberrepo { get; }
        public IGenariceRepo<Borrowing> Borrowingrepo { get; }
        public void Save();
    }
}
