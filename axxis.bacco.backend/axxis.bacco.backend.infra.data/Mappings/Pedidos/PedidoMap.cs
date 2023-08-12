using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Produtos;
using axxis.bacco.domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Mappings.Pedidos
{

    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        private readonly ModelBuilder _modelBuilder;

        public PedidoMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            _modelBuilder.HasSequence<long>("Pedidos_Id_seq");

            builder.ToTable("Pedidos");

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.ValorVenda)
                .IsRequired();

            builder.Property(c => c.Quantidade)
                .IsRequired();

            builder.Property(c => c.HoraPedido)
                .IsRequired();            

            builder.HasKey(c => c.Id).HasName("PK_PEDIDOS");           

            _modelBuilder.Entity<Pedido>()
                .HasOne<Comanda>("Comanda")
                .WithMany()
                .HasForeignKey(ped => ped.ComandaId)
                .HasPrincipalKey(com => com.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PEDIDO_COMANDA");

            _modelBuilder.Entity<Pedido>()
                .HasOne<Produto>("Produto")
                .WithOne()
                .HasForeignKey<Produto>(prd => prd.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PEDIDO_PRODUTO");
        }
    }
}
