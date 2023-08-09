namespace axxis.bacco.domain.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        long NewId();
        IQueryable<T> GetAll();
        Task<T> GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
