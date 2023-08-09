using axxis.bacco.domain.Comandas.Enums;
using axxis.bacco.domain.Core;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;

namespace axxis.bacco.domain.Comandas
{
    public class Comanda : BaseEntity
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public StatusComanda Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Mesa { get; set; }
        
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
