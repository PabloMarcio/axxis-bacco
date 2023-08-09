using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Pedidos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace axxis.bacco.backend.infra.data.Repositories.Pedidos
{
    public class PedidoQuery : IPedidoQuery
    {
        private BaccoContext _context;
        private IQueryable<Pedido> _query;

        public PedidoQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<Pedido, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.Pedidos.Where(expression).Include(p => p.Comanda).Include(p => p.Produto);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IPedidoQuery FilterByComandaId(long id)
        {
            And(x => x.ComandaId == id);
            return this;
        }

        public IPedidoQuery FilterById(long id)
        {
            And(x => x.Id == id);   
            return this;
        }

        public IPedidoQuery FilterByProdutoId(long id)
        {
            And(x=> x.ProdutoId == id);
            return this;
        }

        public IPedidoQuery FilterByTimestamp(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            And(x => x.HoraPedido.Between(dateTimeFrom, dateTimeTo));
            return this;
        }

        public IPedidoQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<Pedido>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<Pedido>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
