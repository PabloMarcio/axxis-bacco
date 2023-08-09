using axxis.bacco.domain.Vendas.Repositories;
using axxis.bacco.domain.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.FormasPagamento.Repositories
{
    public interface IFormaPagamentoQuery
    {
        IFormaPagamentoQuery GetAll();
        IFormaPagamentoQuery FilterById(long id);        
        IFormaPagamentoQuery FilterByName(string partialName);        
        Task<IQueryable<FormaPagamento>> ToListASync();
    }
}
