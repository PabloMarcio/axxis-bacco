using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.FormasPagamento;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Mappings.FormasPagamento
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamento>
    {
        private readonly ModelBuilder _modelBuilder;

        public FormaPagamentoMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            _modelBuilder.HasSequence<long>("FormasPagamento_Id_seq");

            builder.ToTable("FORMASPAGAMENTO");

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();            

            builder.HasKey(c => c.Id).HasName("PK_FORMASPAGAMENTO");            
        }
    }
}
