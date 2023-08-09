using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Pedidos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Repositories.Pedidos
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<Pedido> _dbSet;

        public PedidoRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dbSet = context.Set<Pedido>();
        }

        public void Add(Pedido entity)
        {
            _dbSet.Add(entity);
        }

        public IPedidoQuery CreateQuery()
        {
            return new PedidoQuery(_context);
        }

        public void Delete(Pedido entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Pedido> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Pedido> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("SEQ_PEDIDOS");
        }

        public void Update(Pedido entity)
        {
            _dbSet.Update(entity);
        }
    }
}
