using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Comandas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Repositories.Comandas
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<Comanda> _dbSet;

        public ComandaRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dbSet = context.Set<Comanda>();            
        }

        public void Add(Comanda entity)
        {
            _dbSet.Add(entity);
        }

        public IComandaQuery CreateQuery()
        {
            return new ComandaQuery(_context);
        }

        public void Delete(Comanda entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Comanda> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Comanda> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("SEQ_COMANDAS");
        }

        public void Update(Comanda entity)
        {
            _dbSet.Update(entity);
        }
    }
}
