using axxis.bacco.application.Usuarios.Requests;
using axxis.bacco.application.Usuarios.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.application.Usuarios.Interfaces
{
    public interface IUsuarioService
    {
        Task<SignUpResponse> SignUp(SignUpRequest request);
        RolesListResponse GetRolesList();
    }
}
