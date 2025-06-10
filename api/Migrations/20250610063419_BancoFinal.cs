using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Art_Sabores.Migrations
{
    /// <inheritdoc />
    public partial class BancoFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProdutos_PedidosCliente_pedidoClienteId",
                table: "ItemProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemProdutos_Salgados_salgadoId",
                table: "ItemProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsMateriaPrima_MateriaPrimas_materiaPrimaId",
                table: "ItemsMateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_MateriaPrimas_materiaPrimaId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Salgados_salgadoId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_Receita_Clientes_clienteId",
                table: "Vendas_Clientes_Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_Receita_PedidosCliente_pedidoClienteId",
                table: "Vendas_Clientes_Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemProdutos",
                table: "ItemProdutos");

            migrationBuilder.RenameTable(
                name: "ItemProdutos",
                newName: "ItemSalgados");

            migrationBuilder.RenameColumn(
                name: "Id_Fornecedor",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "IdFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProdutos_salgadoId",
                table: "ItemSalgados",
                newName: "IX_ItemSalgados_salgadoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProdutos_pedidoClienteId",
                table: "ItemSalgados",
                newName: "IX_ItemSalgados_pedidoClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clienteId",
                table: "Vendas_Clientes_Receita",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "salgadoId",
                table: "Receitas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "materiaPrimaId",
                table: "Receitas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "materiaPrimaId",
                table: "ItemsMateriaPrima",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "salgadoId",
                table: "ItemSalgados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "pedidoClienteId",
                table: "ItemSalgados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSalgados",
                table: "ItemSalgados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSalgados_PedidosCliente_pedidoClienteId",
                table: "ItemSalgados",
                column: "pedidoClienteId",
                principalTable: "PedidosCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSalgados_Salgados_salgadoId",
                table: "ItemSalgados",
                column: "salgadoId",
                principalTable: "Salgados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsMateriaPrima_MateriaPrimas_materiaPrimaId",
                table: "ItemsMateriaPrima",
                column: "materiaPrimaId",
                principalTable: "MateriaPrimas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_MateriaPrimas_materiaPrimaId",
                table: "Receitas",
                column: "materiaPrimaId",
                principalTable: "MateriaPrimas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Salgados_salgadoId",
                table: "Receitas",
                column: "salgadoId",
                principalTable: "Salgados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_Receita_Clientes_clienteId",
                table: "Vendas_Clientes_Receita",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_Receita_PedidosCliente_pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                column: "pedidoClienteId",
                principalTable: "PedidosCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "fornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "pedidoFornecedorId",
                principalTable: "PedidoFornecedores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSalgados_PedidosCliente_pedidoClienteId",
                table: "ItemSalgados");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSalgados_Salgados_salgadoId",
                table: "ItemSalgados");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsMateriaPrima_MateriaPrimas_materiaPrimaId",
                table: "ItemsMateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_MateriaPrimas_materiaPrimaId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Salgados_salgadoId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_Receita_Clientes_clienteId",
                table: "Vendas_Clientes_Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_Receita_PedidosCliente_pedidoClienteId",
                table: "Vendas_Clientes_Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSalgados",
                table: "ItemSalgados");

            migrationBuilder.RenameTable(
                name: "ItemSalgados",
                newName: "ItemProdutos");

            migrationBuilder.RenameColumn(
                name: "IdFornecedor",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "Id_Fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_ItemSalgados_salgadoId",
                table: "ItemProdutos",
                newName: "IX_ItemProdutos_salgadoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemSalgados_pedidoClienteId",
                table: "ItemProdutos",
                newName: "IX_ItemProdutos_pedidoClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteId",
                table: "Vendas_Clientes_Receita",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "salgadoId",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "materiaPrimaId",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "materiaPrimaId",
                table: "ItemsMateriaPrima",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "salgadoId",
                table: "ItemProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pedidoClienteId",
                table: "ItemProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemProdutos",
                table: "ItemProdutos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProdutos_PedidosCliente_pedidoClienteId",
                table: "ItemProdutos",
                column: "pedidoClienteId",
                principalTable: "PedidosCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProdutos_Salgados_salgadoId",
                table: "ItemProdutos",
                column: "salgadoId",
                principalTable: "Salgados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsMateriaPrima_MateriaPrimas_materiaPrimaId",
                table: "ItemsMateriaPrima",
                column: "materiaPrimaId",
                principalTable: "MateriaPrimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_MateriaPrimas_materiaPrimaId",
                table: "Receitas",
                column: "materiaPrimaId",
                principalTable: "MateriaPrimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Salgados_salgadoId",
                table: "Receitas",
                column: "salgadoId",
                principalTable: "Salgados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_Receita_Clientes_clienteId",
                table: "Vendas_Clientes_Receita",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_Receita_PedidosCliente_pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                column: "pedidoClienteId",
                principalTable: "PedidosCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "fornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "pedidoFornecedorId",
                principalTable: "PedidoFornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
