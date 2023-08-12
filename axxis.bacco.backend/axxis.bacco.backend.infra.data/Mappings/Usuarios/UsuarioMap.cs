using axxis.bacco.domain.Comandas;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.data.Mappings.Usuarios
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        private ModelBuilder _modelBuilder;

        public UsuarioMap(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            _modelBuilder.HasSequence<long>("Usuarios_Id_seq");

            builder.ToTable("Usuarios");

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();            

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasMaxLength(11);

            builder.Property(c => c.Telefone)
                .HasMaxLength(14);

            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Endereco)
                .HasMaxLength(150);

            builder.Property(c => c.TipoUsuario)
                .IsRequired();

            builder.HasKey(c => c.Id).HasName("PK_USUARIOS");
        }
    }
}
