using axxis.bacco.domain.Core;

namespace axxis.bacco.domain.FormasPagamento
{
    public class FormaPagamento : BaseEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public FormaPagamento(long id) 
        { 
            Id = id;
            Nome = string.Empty;
        }
    }
}
