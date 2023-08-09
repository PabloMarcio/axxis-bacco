using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Comandas.Enums;
using axxis.bacco.domain.Comandas.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace axxis.bacco.backend.infra.data.Repositories.Comandas
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly BaccoContext _context;
        private IQueryable<Comanda> _query;

        public ComandaQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<Comanda, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.Comandas.Where(expression).Include(m => m.Usuario).Include(p => p.Pedidos);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IComandaQuery FilterById(long id)
        {
            And(x => x.Id == id);
            return this;
        }

        public IComandaQuery FilterByStatus(StatusComanda status)
        {
            And(x => x.Status == status);
            return this;
        }

        public IComandaQuery FilterByTable(string tableIdentifier)
        {
            And(x => x.Mesa.Equals(tableIdentifier));
            return this;
        }

        public IComandaQuery FilterByTimestamp(DateTime timestampFrom, DateTime timestampTo)
        {
            And(x => x.DataAbertura.Between(timestampFrom, timestampTo));
            return this;
        }

        public IComandaQuery FilterByUsuarioId(long id)
        {
            And(x => x.UsuarioId == id);
            return this;
        }

        public IComandaQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<Comanda>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<Comanda>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
