using axxis.bacco.domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.Usuarios.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IUsuarioQuery CreateQuery();
    }
}
