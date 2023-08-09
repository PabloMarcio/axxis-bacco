using axxis.bacco.domain.Core;
using axxis.bacco.domain.FormasPagamento;
using axxis.bacco.domain.ItensVenda;

namespace axxis.bacco.domain.Vendas
{
    public class Venda : BaseEntity
    {
        public long Id { get; set; }
        public DateTime DataHora { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteTelefone { get; set; }
        public string ClienteEmail { get; set; }        
        public long FormaPagamentoId { get; set; }

        public virtual ICollection<ItemVenda> Itens { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
    }
}
