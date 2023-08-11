using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Repositories.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BaccoContext _context;
        private readonly DbSet<Usuario> _dbSet;

        public UsuarioRepository(BaccoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _dbSet = context.Set<Usuario>();
        }

        public void Add(Usuario entity)
        {
            _dbSet.Add(entity);
            _context.SaveChangesAsync();
        }

        public IUsuarioQuery CreateQuery()
        {
            return new UsuarioQuery(_context);
        }

        public void Delete(Usuario entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Usuario> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Usuario> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public long NewId()
        {
            return _context.NextVal("Usuarios_Id_seq");
        }

        public void Update(Usuario entity)
        {
            _dbSet.Update(entity);
        }
    }
}
