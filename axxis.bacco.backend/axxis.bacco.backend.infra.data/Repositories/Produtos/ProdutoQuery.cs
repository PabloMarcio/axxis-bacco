using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Produtos;
using axxis.bacco.domain.Produtos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace axxis.bacco.backend.infra.data.Repositories.Produtos
{
    public class ProdutoQuery : IProdutoQuery
    {
        private BaccoContext _context;
        private IQueryable<Produto> _query;

        public ProdutoQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<Produto, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.Produtos.Where(expression);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IProdutoQuery FilterById(long id)
        {
            And(x => x.Id == id);
            return this;
        }

        public IProdutoQuery FilterByLongDescription(string partialDescription)
        {
            And(x => EF.Functions.ILike(x.DescricaoLonga, $"%{partialDescription}%"));
            return this;
        }

        public IProdutoQuery FilterByShortDescription(string partialDescription)
        {
            And(x => EF.Functions.ILike(x.DescricaoCurta, $"%{partialDescription}%"));
            return this;
        }

        public IProdutoQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<Produto>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<Produto>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
