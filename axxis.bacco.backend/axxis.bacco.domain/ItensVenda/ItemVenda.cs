using axxis.bacco.domain.Core;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Vendas;

namespace axxis.bacco.domain.ItensVenda
{
    public class ItemVenda : BaseEntity
    {
        public long Id { get; set; }
        public long VendaId { get; set; }
        public string DescricaoProduto { get; set; }
        public double ValorVenda { get; set; }        
        public int Quantidade { get; set; }
        public double ValorTotalProduto { get; set; }
        
        public virtual Venda Venda { get; set; }
    }
}
