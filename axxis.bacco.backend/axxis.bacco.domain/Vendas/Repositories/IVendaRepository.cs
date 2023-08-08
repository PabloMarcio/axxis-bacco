using axxis.bacco.domain.Core.Repositories;

namespace axxis.bacco.domain.Vendas.Repositories
{
    public interface IVendaRepository : IRepository<Venda>
    {
        IVendaQuery CreateQuery();
    }
}
