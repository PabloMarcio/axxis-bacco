using axxis.bacco.domain.Core;
using axxis.bacco.domain.Usuarios.Enums;

namespace axxis.bacco.domain.Usuarios
{
    public class Usuario : BaseEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public TipoUsuario TipoUsuario { get; set; }        
    }
}
