using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Art_Sabores.Migrations
{
    /// <inheritdoc />
    public partial class TesteFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Producaos");

            migrationBuilder.RenameColumn(
                name: "produto",
                table: "MateriaPrimas",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "Telefone");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Salgados",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Salgados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "MateriaPrimas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PedidoFornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoFornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeMatPrim = table.Column<int>(type: "int", nullable: false),
                    unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagConstante = table.Column<bool>(type: "bit", nullable: false),
                    Rendimento = table.Column<int>(type: "int", nullable: false),
                    IdMateriaPrima = table.Column<int>(type: "int", nullable: false),
                    materiaPrimaId = table.Column<int>(type: "int", nullable: false),
                    IdSalgado = table.Column<int>(type: "int", nullable: false),
                    salgadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_MateriaPrimas_materiaPrimaId",
                        column: x => x.materiaPrimaId,
                        principalTable: "MateriaPrimas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receitas_Salgados_salgadoId",
                        column: x => x.salgadoId,
                        principalTable: "Salgados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsMateriaPrima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMateriaPrima = table.Column<int>(type: "int", nullable: false),
                    materiaPrimaId = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsMateriaPrima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsMateriaPrima_MateriaPrimas_materiaPrimaId",
                        column: x => x.materiaPrimaId,
                        principalTable: "MateriaPrimas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsMateriaPrima_PedidoFornecedores_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "PedidoFornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas_Fornecedores_MateriaPrima",
                columns: table => new
                {
                    NFE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Fornecedor = table.Column<int>(type: "int", nullable: false),
                    fornecedorId = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    pedidoFornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas_Fornecedores_MateriaPrima", x => x.NFE);
                    table.ForeignKey(
                        name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_fornecedorId",
                        column: x => x.fornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_pedidoFornecedorId",
                        column: x => x.pedidoFornecedorId,
                        principalTable: "PedidoFornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSalgado = table.Column<int>(type: "int", nullable: false),
                    salgadoId = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    pedidoClienteId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemProdutos_PedidosCliente_pedidoClienteId",
                        column: x => x.pedidoClienteId,
                        principalTable: "PedidosCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemProdutos_Salgados_salgadoId",
                        column: x => x.salgadoId,
                        principalTable: "Salgados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas_Clientes_Receita",
                columns: table => new
                {
                    NFE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    pedidoClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas_Clientes_Receita", x => x.NFE);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_Receita_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_Receita_PedidosCliente_pedidoClienteId",
                        column: x => x.pedidoClienteId,
                        principalTable: "PedidosCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemProdutos_pedidoClienteId",
                table: "ItemProdutos",
                column: "pedidoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProdutos_salgadoId",
                table: "ItemProdutos",
                column: "salgadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsMateriaPrima_IdPedido",
                table: "ItemsMateriaPrima",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsMateriaPrima_materiaPrimaId",
                table: "ItemsMateriaPrima",
                column: "materiaPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_materiaPrimaId",
                table: "Receitas",
                column: "materiaPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_salgadoId",
                table: "Receitas",
                column: "salgadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Clientes_Receita_clienteId",
                table: "Vendas_Clientes_Receita",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Clientes_Receita_pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                column: "pedidoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Fornecedores_MateriaPrima_fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "fornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Fornecedores_MateriaPrima_pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "pedidoFornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemProdutos");

            migrationBuilder.DropTable(
                name: "ItemsMateriaPrima");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Vendas_Clientes_Receita");

            migrationBuilder.DropTable(
                name: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropTable(
                name: "PedidosCliente");

            migrationBuilder.DropTable(
                name: "PedidoFornecedores");

            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Salgados");

            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "MateriaPrimas");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MateriaPrimas",
                newName: "produto");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clientes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Clientes",
                newName: "CPF");

            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "Salgados",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaPrimaID = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSalgado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantMatPri = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producaos", x => x.Id);
                });
        }
    }
}
