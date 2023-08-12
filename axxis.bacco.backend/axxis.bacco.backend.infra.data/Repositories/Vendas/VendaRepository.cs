using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Vendas;
using axxis.bacco.domain.Vendas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Repositories.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<Venda> _dbSet;

        public VendaRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _dbSet = context.Set<Venda>();
        }

        public void Add(Venda entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public IVendaQuery CreateQuery()
        {
            return new VendaQuery(_context);
        }

        public void Delete(Venda entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Venda> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Venda> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("Vendas_Id_seq");
        }

        public void Update(Venda entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
