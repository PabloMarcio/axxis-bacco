using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.ItensVenda;
using axxis.bacco.domain.ItensVenda.Repositories;
using Microsoft.EntityFrameworkCore;

namespace axxis.bacco.backend.infra.data.Repositories.ItensVenda
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<ItemVenda> _dbSet;

        public ItemVendaRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dbSet = context.Set<ItemVenda>();
        }

        public void Add(ItemVenda entity)
        {
            _dbSet.Add(entity); 
        }

        public IItemVendaQuery CreateQuery()
        {
            return new ItemVendaQuery(_context);
        }

        public void Delete(ItemVenda entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<ItemVenda> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<ItemVenda> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("SEQ_ITENSVENDA");
        }

        public void Update(ItemVenda entity)
        {
            _dbSet.Update(entity);
        }
    }
}
