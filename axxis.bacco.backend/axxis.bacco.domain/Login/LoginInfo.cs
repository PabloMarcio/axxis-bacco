using axxis.bacco.domain.Usuarios.Enums;

namespace axxis.bacco.domain.Login
{
    public class LoginInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Notifications { get; set; }
        public TipoUsuario Role { get; set; }
        public string Token { get; set; }
    }
}
