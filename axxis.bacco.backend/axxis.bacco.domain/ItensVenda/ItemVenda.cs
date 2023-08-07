using axxis.bacco.domain.Core;
using axxis.bacco.domain.Pedidos;

namespace axxis.bacco.domain.ItensVenda
{
    public class ItemVenda : BaseEntity
    {
        public long Id { get; set; }
        public long VendaId { get; set; }
        public string DescricaoProduto { get; set; }
        public double ValorProduto { get; set; }        
        public int Quantidade { get; set; }
        public double ValorTotalProduto { get; set; }

        public ItemVenda(long id, Pedido pedido)
        {
            Id = id;
            VendaId = 0;
            DescricaoProduto = pedido.Produto.DescricaoCurta;
            ValorProduto = pedido.Produto.ValorUnitario;
            Quantidade = pedido.Quantidade;
            ValorTotalProduto = ValorProduto * Quantidade;
        }
    }
}
