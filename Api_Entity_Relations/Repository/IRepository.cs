namespace Api_Entity_Relations.Repository
{
    public interface IRepository<T>: IDisposable where T : class
    {
        public Task<IEnumerable<T>> findAll();

        public Task<T> save(T entity);
      //  public Task<T> findById(int id);
       // public Task<T> save(T entity);
    }
}
