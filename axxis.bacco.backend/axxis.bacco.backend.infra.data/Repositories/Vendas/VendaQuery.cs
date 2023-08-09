using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Vendas;
using axxis.bacco.domain.Vendas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace axxis.bacco.backend.infra.data.Repositories.Vendas
{
    public class VendaQuery : IVendaQuery
    {
        private BaccoContext _context;
        private IQueryable<Venda> _query;

        public VendaQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<Venda, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.Vendas.Where(expression).Include(v => v.FormaPagamento).Include(v => v.Itens);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IVendaQuery FilterByClientCPF(string cpf)
        {
            And(x => x.ClienteCPF.Equals(cpf));
            return this;
        }

        public IVendaQuery FilterByClientEmail(string partialMailAddress)
        {
            And(x => EF.Functions.ILike(x.ClienteEmail, $"%{partialMailAddress}%"));
            return this;
        }

        public IVendaQuery FilterByClientName(string partialName)
        {
            And(x => EF.Functions.ILike(x.ClienteNome, $"%{partialName}%"));
            return this;
        }

        public IVendaQuery FilterByClientTelephone(string partialPhone)
        {
            And(x => EF.Functions.ILike(x.ClienteTelefone, $"%{partialPhone}%"));
            return this;
        }

        public IVendaQuery FilterById(long id)
        {
            And(x => x.Id == id);
            return this;
        }

        public IVendaQuery FilterByPaymentMethod(long formaPagamentoId)
        {
            And(x => x.FormaPagamentoId == formaPagamentoId);
            return this;
        }

        public IVendaQuery FilterByPeriod(DateTime dateFrom, DateTime dateTo)
        {
            And(x => x.DataHora.Between(dateFrom, dateTo));
            return this;
        }

        public IVendaQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<Venda>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<Venda>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
