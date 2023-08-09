using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.ItensVenda;
using axxis.bacco.domain.ItensVenda.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace axxis.bacco.backend.infra.data.Repositories.ItensVenda
{
    public class ItemVendaQuery : IItemVendaQuery
    {
        private readonly BaccoContext _context;
        private IQueryable<ItemVenda> _query;

        public ItemVendaQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<ItemVenda, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.ItensVenda.Where(expression).Include(i => i.Venda);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IItemVendaQuery FilterById(long id)
        {
            And(x => x.Id == id);
            return this;
        }

        public IItemVendaQuery FilterByProductDescription(string partialDescription)
        {
            And(x => EF.Functions.ILike(x.DescricaoProduto, $"%{partialDescription}%"));
            return this;
        }

        public IItemVendaQuery FilterByVendaId(long id)
        {
            And(x => x.VendaId == id);
            return this;
        }

        public IItemVendaQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<ItemVenda>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<ItemVenda>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
