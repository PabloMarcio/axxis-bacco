﻿using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.FormasPagamento;
using axxis.bacco.domain.FormasPagamento.Repositories;
using Microsoft.EntityFrameworkCore;

namespace axxis.bacco.backend.infra.data.Repositories.FormasPagamento
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<FormaPagamento> _dbSet;

        public FormaPagamentoRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dbSet = context.Set<FormaPagamento>();
        }

        public void Add(FormaPagamento entity)
        {
            _dbSet.Add(entity);
        }

        public IFormaPagamentoQuery CreateQuery()
        {
            return new FormaPagamentoQuery(_context);
        }

        public void Delete(FormaPagamento entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<FormaPagamento> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<FormaPagamento> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("SEQ_FORMASPAGAMENTO");
        }

        public void Update(FormaPagamento entity)
        {
            _dbSet.Update(entity);
        }
    }
}