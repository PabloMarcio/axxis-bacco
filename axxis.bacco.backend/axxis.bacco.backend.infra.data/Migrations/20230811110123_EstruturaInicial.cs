using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace axxis.bacco.backend.infra.data.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Comandas_Id_seq");

            migrationBuilder.CreateSequence(
                name: "FormasPagamento_Id_seq");

            migrationBuilder.CreateSequence(
                name: "ItensVenda_Id_seq");

            migrationBuilder.CreateSequence(
                name: "Pedidos_Id_seq");

            migrationBuilder.CreateSequence(
                name: "Produtos_Id_seq");

            migrationBuilder.CreateSequence(
                name: "Usuarios_Id_seq");

            migrationBuilder.CreateSequence(
                name: "Vendas_Id_seq");

            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMASPAGAMENTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TipoUsuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClienteNome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ClienteCPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ClienteTelefone = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    ClienteEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FormaPagamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VENDA_PAGAMENTO",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormasPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Mesa = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMANDAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMANDA_USUARIO",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    VendaId = table.Column<long>(type: "bigint", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorTotalProduto = table.Column<double>(type: "double precision", nullable: false),
                    VendaId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENSVENDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITENSVENDA_VENDA",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Vendas_VendaId1",
                        column: x => x.VendaId1,
                        principalTable: "Vendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ComandaId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    HoraPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ComandaId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PEDIDO_COMANDA",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Comandas_ComandaId1",
                        column: x => x.ComandaId1,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Base64Image = table.Column<string>(type: "character varying(614400)", maxLength: 614400, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false),
                    DescricaoLonga = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    ValorUnitario = table.Column<double>(type: "double precision", nullable: false),
                    TipoPedido = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PEDIDO_PRODUTO",
                        column: x => x.Id,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_COMANDA_DATAABERTURA",
                table: "Comandas",
                column: "DataAbertura");

            migrationBuilder.CreateIndex(
                name: "IDX_COMANDA_MESA",
                table: "Comandas",
                column: "Mesa");

            migrationBuilder.CreateIndex(
                name: "IDX_COMANDA_STATUS",
                table: "Comandas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_UsuarioId",
                table: "Comandas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IDX_ITENSVENDA_DESCRICAO",
                table: "ItensVenda",
                column: "DescricaoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_VendaId",
                table: "ItensVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_VendaId1",
                table: "ItensVenda",
                column: "VendaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComandaId",
                table: "Pedidos",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComandaId1",
                table: "Pedidos",
                column: "ComandaId1");

            migrationBuilder.CreateIndex(
                name: "IDX_PRODUTO_DESCL",
                table: "Produto",
                column: "DescricaoLonga");

            migrationBuilder.CreateIndex(
                name: "IDX_PRODUTO_DESCRICAO",
                table: "Produto",
                column: "DescricaoCurta");

            migrationBuilder.CreateIndex(
                name: "IDX_PRODUTO_TIPO",
                table: "Produto",
                column: "TipoPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FormaPagamentoId",
                table: "Vendas",
                column: "FormaPagamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVenda");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropSequence(
                name: "Comandas_Id_seq");

            migrationBuilder.DropSequence(
                name: "FormasPagamento_Id_seq");

            migrationBuilder.DropSequence(
                name: "ItensVenda_Id_seq");

            migrationBuilder.DropSequence(
                name: "Pedidos_Id_seq");

            migrationBuilder.DropSequence(
                name: "Produtos_Id_seq");

            migrationBuilder.DropSequence(
                name: "Usuarios_Id_seq");

            migrationBuilder.DropSequence(
                name: "Vendas_Id_seq");
        }
    }
}
