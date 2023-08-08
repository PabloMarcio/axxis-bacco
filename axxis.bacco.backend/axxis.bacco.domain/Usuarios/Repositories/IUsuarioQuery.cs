using axxis.bacco.domain.Vendas.Repositories;
using axxis.bacco.domain.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using axxis.bacco.domain.Usuarios.Enums;

namespace axxis.bacco.domain.Usuarios.Repositories
{
    public interface IUsuarioQuery
    {
        IUsuarioQuery GetAll();
        IUsuarioQuery FilterById(long id);
        IUsuarioQuery FilterByName(string partialName);
        IUsuarioQuery FilterByBirthDate(DateTime dateFrom, DateTime dateTo);
        IUsuarioQuery FilterByCPF(string cpf);
        IUsuarioQuery FilterByPhone(string phoneNumber);
        IUsuarioQuery FilterByEmail(string partialMailAddress);
        IUsuarioQuery FilterByAddress(string partialAddress);
        IUsuarioQuery FilterByRole(TipoUsuario role);
        Task<IQueryable<Usuario>> ToListASync();
    }
}
