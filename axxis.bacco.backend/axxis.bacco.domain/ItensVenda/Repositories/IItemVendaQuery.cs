using axxis.bacco.domain.Vendas.Repositories;
using axxis.bacco.domain.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.ItensVenda.Repositories
{
    public interface IItemVendaQuery
    {
        IItemVendaQuery GetAll();
        IItemVendaQuery FilterById(long id);
        IItemVendaQuery FilterByVendaId(long id);
        IItemVendaQuery FilterByProductDescription(string partialDescription);
        Task<IQueryable<ItemVenda>> ToListASync();        
    }
}
