using axxis.bacco.domain.Comandas.Enums;
using axxis.bacco.domain.Core;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;

namespace axxis.bacco.domain.Comandas
{
    public class Comanda : BaseEntity
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public StatusComanda Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Comanda(long id, Usuario usuario) 
        { 
            Id = id;
            Usuario = usuario;
            Status = StatusComanda.Aberta;
            DataAbertura = DateTime.Now;
            Pedidos = new List<Pedido>();
        }

        public Comanda AdicionarPedido(Pedido pedido)
        {
            pedido.ComandaId = Id;
            Pedidos.Add(pedido);
            return this;
        }
        
        public double ObterValorTotal()
        {
            double valorTotal = 0;
            foreach (var pedido in Pedidos)
            {
                valorTotal += pedido.Produto.ValorUnitario * pedido.Quantidade;
            }
            return valorTotal;
        }
    }
}
