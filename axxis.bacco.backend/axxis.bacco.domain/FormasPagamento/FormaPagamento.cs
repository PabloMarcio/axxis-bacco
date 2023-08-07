namespace axxis.bacco.domain.FormasPagamento
{
    public class FormaPagamento
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
