using axxis.bacco.domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.ItensVenda.Repositories
{
    public interface IItemVendaRepository : IRepository<ItemVenda>
    {
        IItemVendaQuery CreateQuery();
    }
}
