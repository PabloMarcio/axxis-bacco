using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Produtos;

namespace axxis.bacco.domain.Pedidos
{
    public class Pedido
    {
        public long Id { get; set; }
        public long ComandaId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime HoraPedido { get; set; }

        public Pedido(long id, Produto produto, int quantidade)
        {
            Id = id;
            ComandaId = 0;
            Produto = produto;
            Quantidade = quantidade;
            HoraPedido = DateTime.Now;
        }
    }
}
