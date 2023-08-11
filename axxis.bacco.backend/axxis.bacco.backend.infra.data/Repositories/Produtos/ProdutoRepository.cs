using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Produtos;
using axxis.bacco.domain.Produtos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Repositories.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<Produto> _dbSet;

        public ProdutoRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dbSet = context.Set<Produto>();
        }

        public void Add(Produto entity)
        {
            _dbSet.Add(entity);
        }

        public IProdutoQuery CreateQuery()
        {
            return new ProdutoQuery(_context);
        }

        public void Delete(Produto entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Produto> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Produto> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("Produtos_Id_seq");
        }

        public void Update(Produto entity)
        {
            _dbSet.Update(entity);
        }
    }
}
