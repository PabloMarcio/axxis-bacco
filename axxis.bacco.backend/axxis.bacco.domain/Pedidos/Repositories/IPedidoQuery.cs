using axxis.bacco.domain.Vendas.Repositories;
using axxis.bacco.domain.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.Pedidos.Repositories
{
    public interface IPedidoQuery
    {
        IPedidoQuery GetAll();
        IPedidoQuery FilterById(long id);
        IPedidoQuery FilterByComandaId(long id);
        IPedidoQuery FilterByProdutoId(long id);
        IPedidoQuery FilterByTimestamp(DateTime dateTimeFrom, DateTime dateTimeTo);
        Task<IQueryable<Pedido>> ToListASync();
    }
}
