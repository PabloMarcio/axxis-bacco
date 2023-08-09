using axxis.bacco.backend.infra.data.Contexts;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Usuarios.Enums;
using axxis.bacco.domain.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace axxis.bacco.backend.infra.data.Repositories.Usuarios
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private BaccoContext _context;
        private IQueryable<Usuario> _query;

        public UsuarioQuery(BaccoContext context)
        {
            _context = context;
        }

        private void And(Expression<Func<Usuario, bool>> expression)
        {
            if (_query == null)
            {
                _query = _context.Usuarios.Where(expression);
            }
            else
            {
                _query = _query.Where(expression);
            }
        }

        public IUsuarioQuery FilterByAddress(string partialAddress)
        {
            And(x => EF.Functions.ILike(x.Endereco, $"%{partialAddress}%"));
            return this;
        }

        public IUsuarioQuery FilterByBirthDate(DateTime dateFrom, DateTime dateTo)
        {
            And(x => x.DataNascimento.Between(dateFrom, dateTo));
            return this;
        }

        public IUsuarioQuery FilterByCPF(string cpf)
        {
            And(x => x.Cpf.Equals(cpf));
            return this;
        }

        public IUsuarioQuery FilterByEmail(string partialMailAddress)
        {
            And(x => EF.Functions.ILike(x.Email, $"%{partialMailAddress}%"));
            return this;
        }

        public IUsuarioQuery FilterById(long id)
        {
            And(x => x.Id == id);
            return this;
        }

        public IUsuarioQuery FilterByName(string partialName)
        {
            And(x => EF.Functions.ILike(x.Nome, $"%{partialName}%"));
            return this;
        }

        public IUsuarioQuery FilterByPhone(string phoneNumber)
        {
            And(x => x.Telefone == phoneNumber);
            return this;
        }

        public IUsuarioQuery FilterByRole(TipoUsuario role)
        {
            And(x => x.TipoUsuario == role);
            return this;
        }

        public IUsuarioQuery GetAll()
        {
            And(x => x.Id > 0);
            return this;
        }

        public async Task<IQueryable<Usuario>> ToListASync()
        {
            if (_query == null) GetAll();
            if (_query == null) return new List<Usuario>().AsQueryable();
            var result = await _query.ToListAsync();
            return result.AsQueryable();
        }
    }
}
