using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace axxis.bacco.backend.infra.data.Mappings.Comandas
{
    public class ComandaMap : IEntityTypeConfiguration<Comanda>
    {
        private ModelBuilder _modelBuilder;

        public ComandaMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            _modelBuilder.HasSequence<long>("Comandas_Id_seq");            

            builder.ToTable("Comandas");

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.UsuarioId)
                .IsRequired();

            builder.Property(c => c.Status)
                .IsRequired();

            builder.Property(c => c.DataAbertura)
                .IsRequired();

            builder.Property(c => c.Mesa)
                .HasMaxLength(20);

            builder.HasKey(c => c.Id).HasName("PK_COMANDAS");
            builder.HasIndex(c => c.Mesa).HasDatabaseName("IDX_COMANDA_MESA");
            builder.HasIndex(c => c.Status).HasDatabaseName("IDX_COMANDA_STATUS");
            builder.HasIndex(c => c.DataAbertura).HasDatabaseName("IDX_COMANDA_DATAABERTURA");

            _modelBuilder.Entity<Comanda>()
                .HasOne<Usuario>("Usuario")
                .WithMany()
                .HasForeignKey(com => com.UsuarioId)
                .HasPrincipalKey(usr => usr.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_COMANDA_USUARIO");

            _modelBuilder.Entity<Comanda>()
                .HasMany<Pedido>("Pedidos")
                .WithOne()
                .HasForeignKey(ped => ped.ComandaId)
                .HasPrincipalKey(com => com.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PEDIDO_COMANDA");
        }
    }
}
