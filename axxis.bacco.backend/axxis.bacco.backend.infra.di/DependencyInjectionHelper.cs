using axxis.bacco.backend.infra.data.Repositories.Comandas;
using axxis.bacco.backend.infra.data.Repositories.FormasPagamento;
using axxis.bacco.backend.infra.data.Repositories.ItensVenda;
using axxis.bacco.backend.infra.data.Repositories.Pedidos;
using axxis.bacco.backend.infra.data.Repositories.Produtos;
using axxis.bacco.backend.infra.data.Repositories.Usuarios;
using axxis.bacco.backend.infra.data.Repositories.Vendas;
using axxis.bacco.domain.Comandas.Repositories;
using axxis.bacco.domain.FormasPagamento.Repositories;
using axxis.bacco.domain.ItensVenda.Repositories;
using axxis.bacco.domain.Pedidos.Repositories;
using axxis.bacco.domain.Produtos.Repositories;
using axxis.bacco.domain.Usuarios.Repositories;
using axxis.bacco.domain.Vendas.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace axxis.bacco.backend.infra.di
{
    public class DependencyInjectionHelper
    {
        public static void Configure(IServiceCollection services)
        {
            //repositories
            services.AddScoped<IComandaRepository, ComandaRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
        }
    }
}