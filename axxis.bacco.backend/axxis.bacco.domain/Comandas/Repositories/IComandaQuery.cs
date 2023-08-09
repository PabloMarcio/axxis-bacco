using axxis.bacco.domain.Comandas.Enums;

namespace axxis.bacco.domain.Comandas.Repositories
{
    public interface IComandaQuery
    {
        IComandaQuery GetAll();
        IComandaQuery FilterById(long id);
        IComandaQuery FilterByUsuarioId(long id);
        IComandaQuery FilterByStatus(StatusComanda status);
        IComandaQuery FilterByTimestamp(DateTime timestampFrom, DateTime timestampTo);
        IComandaQuery FilterByTable(string tableIdentifier);
        Task<IQueryable<Comanda>> ToListASync();
    }
}
