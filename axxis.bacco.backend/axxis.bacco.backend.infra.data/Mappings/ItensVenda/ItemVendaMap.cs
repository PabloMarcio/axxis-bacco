using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.ItensVenda;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace axxis.bacco.backend.infra.data.Mappings.ItensVenda
{
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        private readonly ModelBuilder _modelBuilder;

        public ItemVendaMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            _modelBuilder.HasSequence<long>("ItensVenda_Id_seq");
                        
            builder.ToTable("ItensVenda");

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.VendaId)
                .IsRequired();

            builder.Property(c => c.DescricaoProduto)
                .HasMaxLength(140)
                .IsRequired();

            builder.Property(c => c.ValorVenda)
                .IsRequired();

            builder.Property(c => c.Quantidade)
                .IsRequired();

            builder.Property(c => c.ValorTotalProduto)
                .IsRequired(); 

            builder.HasKey(c => c.Id).HasName("PK_ITENSVENDA");
            builder.HasIndex(c => c.DescricaoProduto).HasDatabaseName("IDX_ITENSVENDA_DESCRICAO");
            
            _modelBuilder.Entity<ItemVenda>()
                .HasOne<Venda>("Venda")
                .WithMany()
                .HasForeignKey(itv => itv.VendaId)
                .HasPrincipalKey(ven => ven.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ITENSVENDA_VENDA");            
        }
    }
}
