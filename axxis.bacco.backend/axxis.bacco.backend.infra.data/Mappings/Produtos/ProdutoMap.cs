using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Produtos;
using axxis.bacco.domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace axxis.bacco.backend.infra.data.Mappings.Produtos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        private readonly ModelBuilder _modelBuilder;

        public ProdutoMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            _modelBuilder.HasSequence<long>("SEQ_PRODUTOS");

            builder.ToTable("PRODUTO");            

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.Base64Image)
                .HasMaxLength(600 * 1024); // 600k no maximo

            builder.Property(c => c.DescricaoCurta)
                .HasMaxLength(140)
                .IsRequired();

            builder.Property(c => c.DescricaoLonga)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(c => c.ValorUnitario)
                .IsRequired();

            builder.Property(c => c.TipoPedido)
                .IsRequired();

            builder.HasKey(c => c.Id).HasName("PK_PRODUTOS");
            builder.HasIndex(c => c.DescricaoCurta).HasDatabaseName("IDX_PRODUTO_DESCRICAO");
            builder.HasIndex(c => c.DescricaoLonga).HasDatabaseName("IDX_PRODUTO_DESCL");
            builder.HasIndex(c => c.TipoPedido).HasDatabaseName("IDX_PRODUTO_TIPO");            
        }
    }
}
