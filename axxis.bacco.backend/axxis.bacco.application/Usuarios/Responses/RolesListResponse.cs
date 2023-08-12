using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.application.Usuarios.Responses
{
    public class RolesListResponse
    {
        public List<Role> Roles { get; set; } = new List<Role>();
    }

    public class Role
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
