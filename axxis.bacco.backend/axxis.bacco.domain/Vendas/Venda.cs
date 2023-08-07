using axxis.bacco.domain.Comandas;
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
        public List<ItemVenda> Itens { get; set; }
        public string FormaPagamentoNome { get; set; }

        public Venda(long id, Comanda comanda, FormaPagamento formaPagamento)
        {
            Id = id;
            DataHora = DateTime.Now;
            ClienteNome = comanda.Usuario.Nome;
            ClienteCPF = comanda.Usuario.Cpf;
            ClienteTelefone = comanda.Usuario.Telefone;
            ClienteEmail = comanda.Usuario.Email;
            Itens = new();
            long itemId = 0;
            foreach (var pedido in comanda.Pedidos) 
            {
                itemId++;
                var item = new ItemVenda(itemId, pedido);
                item.VendaId = id;
                Itens.Add(item);
            }
            FormaPagamentoNome = formaPagamento.Nome;
        }
    }
}
