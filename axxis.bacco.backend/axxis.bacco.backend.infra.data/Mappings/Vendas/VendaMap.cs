using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.FormasPagamento;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Mappings.Vendas
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        private ModelBuilder _modelBuilder;

        public VendaMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            _modelBuilder.HasSequence<long>("Vendas_Id_seq");

            builder.ToTable("VENDAS");

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();            

            builder.Property(c => c.DataHora)
                .IsRequired();

            builder.Property(c => c.ClienteNome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ClienteCPF)
                .HasMaxLength(11);

            builder.Property(c => c.ClienteTelefone)
                .HasMaxLength(14);

            builder.Property(c => c.ClienteEmail)
                .HasMaxLength(100);

            builder.Property(c => c.FormaPagamentoId)
                .IsRequired();

            builder.HasKey(c => c.Id).HasName("PK_VENDAS");            

            _modelBuilder.Entity<Venda>()
                .HasOne<FormaPagamento>("FormaPagamento")
                .WithMany()
                .HasForeignKey(ven => ven.FormaPagamentoId)
                .HasPrincipalKey(pgt => pgt.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_VENDA_PAGAMENTO");
        }
    }
}
