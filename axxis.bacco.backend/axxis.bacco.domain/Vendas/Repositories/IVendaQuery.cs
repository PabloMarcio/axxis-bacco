using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.Vendas.Repositories
{
    public interface IVendaQuery
    {
        IVendaQuery GetAll();
        IVendaQuery FilterById(long id);
        IVendaQuery FilterByPeriod(DateTime dateFrom, DateTime dateTo);
        IVendaQuery FilterByClientName(string partialName);
        IVendaQuery FilterByClientCPF(string cpf);
        IVendaQuery FilterByClientTelephone(string partialPhone);
        IVendaQuery FilterByClientEmail(string partialMailAddress);
        IVendaQuery FilterByPaymentMethod(long formaPagamentoId);        
        Task<IQueryable<Venda>> ToListASync();
    }
}
