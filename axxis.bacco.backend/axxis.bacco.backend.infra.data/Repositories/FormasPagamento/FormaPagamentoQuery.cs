using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.FormasPagamento;
using axxis.bacco.domain.FormasPagamento.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace axxis.bacco.backend.infra.data.Repositories.FormasPagamento
{
    public class FormaPagamentoQuery : IFormaPagamentoQuery
    {
        private BaccoContext _context;
        private IQueryable<FormaPagamento> _query;

        public FormaPagamentoQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<FormaPagamento, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.FormasPagamento.Where(expression);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IFormaPagamentoQuery FilterById(long id)
        {
            And(x => x.Id == id);
            return this;
        }

        public IFormaPagamentoQuery FilterByName(string partialName)
        {
            And(x => EF.Functions.ILike(x.Nome, $"%{partialName}%"));
            return this;
        }

        public IFormaPagamentoQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<FormaPagamento>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<FormaPagamento>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
