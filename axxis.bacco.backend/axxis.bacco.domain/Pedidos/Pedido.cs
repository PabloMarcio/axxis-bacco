using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Core;
using axxis.bacco.domain.Produtos;

namespace axxis.bacco.domain.Pedidos
{
    public class Pedido : BaseEntity
    {
        public long Id { get; set; }
        public long ComandaId { get; set; }
        public long ProdutoId { get; set; }
        public double ValorVenda { get; set; }
        public int Quantidade { get; set; }
        public DateTime HoraPedido { get; set; }
        
        public virtual Comanda Comanda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
