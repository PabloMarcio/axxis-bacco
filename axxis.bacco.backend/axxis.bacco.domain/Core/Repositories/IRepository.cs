namespace axxis.bacco.domain.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        double NewId(string generator);
        IQueryable<T> GetAll();
        Task<T> GetById(double id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
