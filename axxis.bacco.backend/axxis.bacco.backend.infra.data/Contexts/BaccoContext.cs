using axxis.bacco.backend.infra.configuration;
using axxis.bacco.domain.Comandas;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Core.Repositories;
using axxis.bacco.domain.FormasPagamento;
using axxis.bacco.domain.ItensVenda;
using axxis.bacco.domain.Pedidos;
using axxis.bacco.domain.Produtos;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Vendas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using axxis.bacco.backend.infra.data.Mappings.Usuarios;
using axxis.bacco.backend.infra.data.Mappings.Vendas;
using axxis.bacco.backend.infra.data.Mappings.Produtos;
using axxis.bacco.backend.infra.data.Mappings.Pedidos;
using axxis.bacco.backend.infra.data.Mappings.ItensVenda;
using axxis.bacco.backend.infra.data.Mappings.FormasPagamento;
using axxis.bacco.backend.infra.data.Mappings.Comandas;

namespace axxis.bacco.backend.infra.data.Contexts
{
    public class BaccoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }

        public BaccoContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql("User ID=postgres;Password=4xx15;Host=localhost;Port=5432;Database=bacco;Pooling=true;Connection Lifetime=0;SearchPath=public;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new VendaMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProdutoMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new PedidoMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ItemVendaMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FormaPagamentoMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ComandaMap(modelBuilder));


            base.OnModelCreating(modelBuilder);
        }

        public long NextVal(string sequenceName)
        {
            using (var cmd = this.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT nextval('{0}.\"{1}\"')", Schema, sequenceName);
                this.Database.OpenConnection();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var result = (long)reader.GetValue(0);
                this.Database.CloseConnection();

                return result;
            }
        }

        public static string ConnectionString
        {
            get
            {
                var mask = "User ID={USERID};Password={PASSWORD};Host={HOST};Port={PORT};Database={DATABASENAME};Pooling=true;Connection Lifetime=0;SearchPath={SCHEMA};";
                mask = mask.Replace("{USERID}", ConfigurationInfo.GetDatabaseUserId());
                mask = mask.Replace("{PASSWORD}", ConfigurationInfo.GetDatabasePassword().FromBase64());
                mask = mask.Replace("{HOST}", ConfigurationInfo.GetDatabaseHost());
                mask = mask.Replace("{PORT}", ConfigurationInfo.GetDatabasePort());
                mask = mask.Replace("{DATABASENAME}", ConfigurationInfo.GetDatabaseName());
                mask = mask.Replace("{SCHEMA}", ConfigurationInfo.GetDatabaseSchema());
#if DEBUG
                mask = "User ID=postgres;Password=4xx15;Host=localhost;Port=5432;Database=bacco;Pooling=true;Connection Lifetime=0;SearchPath=public;";
#endif
                return mask;
            }
        }

        public string Schema
        {
            get
            {
#if DEBUG
                return "public";
#endif
                return ConnectionString
                    .Split(';')
                    .Where(x => string.IsNullOrEmpty(x) == false)
                    .Select(x => x.Split('='))
                    .ToDictionary(x => x[0], x => x[1])["SearchPath"];
            }
        }
    }
}


