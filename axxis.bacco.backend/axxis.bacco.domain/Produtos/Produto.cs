using axxis.bacco.domain.Core;
using axxis.bacco.domain.Produtos.Enums;

namespace axxis.bacco.domain.Produtos
{
    public class Produto : BaseEntity
    {
        public long Id { get; set; } 
        public string Base64Image { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public double ValorUnitario { get; set; }
        public TipoPedido TipoPedido { get; set; }

        public Produto(long id)
        {
            Id = id;
            Base64Image = string.Empty;
            DescricaoCurta = string.Empty;
            DescricaoLonga = string.Empty;
            ValorUnitario = 0;
            TipoPedido = new TipoPedido();
        }        
    }
}
