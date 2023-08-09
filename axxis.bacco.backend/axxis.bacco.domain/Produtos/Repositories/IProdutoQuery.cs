using axxis.bacco.domain.Vendas.Repositories;
using axxis.bacco.domain.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using axxis.bacco.domain.Produtos.Enums;

namespace axxis.bacco.domain.Produtos.Repositories
{
    public interface IProdutoQuery
    {
        IProdutoQuery GetAll();
        IProdutoQuery FilterById(long id);
        IProdutoQuery FilterByShortDescription(string partialDescription);
        IProdutoQuery FilterByLongDescription(string partialDescription);        
        Task<IQueryable<Produto>> ToListASync();
    }
}
