namespace LibrarySystem.Repo.Interface
{
    public interface IGenariceRepo<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
