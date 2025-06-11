using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Art_Sabores.Migrations
{
    /// <inheritdoc />
    public partial class BancoConcluidoFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_ItemsMateriaPrima_PedidoFornecedores_IdPedido",
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

            migrationBuilder.DropIndex(
                name: "IX_ItemsMateriaPrima_IdPedido",
                table: "ItemsMateriaPrima");

            migrationBuilder.DropIndex(
                name: "IX_ItemSalgados_pedidoClienteId",
                table: "ItemSalgados");

            migrationBuilder.DropIndex(
                name: "IX_ItemSalgados_salgadoId",
                table: "ItemSalgados");

            migrationBuilder.DropColumn(
                name: "pedidoClienteId",
                table: "ItemSalgados");

            migrationBuilder.DropColumn(
                name: "salgadoId",
                table: "ItemSalgados");

            migrationBuilder.RenameColumn(
                name: "pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "PedidoFornecedorId");

            migrationBuilder.RenameColumn(
                name: "fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Fornecedores_MateriaPrima_pedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "IX_Vendas_Fornecedores_MateriaPrima_PedidoFornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Fornecedores_MateriaPrima_fornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "IX_Vendas_Fornecedores_MateriaPrima_FornecedorId");

            migrationBuilder.RenameColumn(
                name: "pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                newName: "PedidoClienteId");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Vendas_Clientes_Receita",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "IdPedido",
                table: "Vendas_Clientes_Receita",
                newName: "IdPedidoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Clientes_Receita_pedidoClienteId",
                table: "Vendas_Clientes_Receita",
                newName: "IX_Vendas_Clientes_Receita_PedidoClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Clientes_Receita_clienteId",
                table: "Vendas_Clientes_Receita",
                newName: "IX_Vendas_Clientes_Receita_ClienteId");

            migrationBuilder.RenameColumn(
                name: "salgadoId",
                table: "Receitas",
                newName: "SalgadoId");

            migrationBuilder.RenameColumn(
                name: "materiaPrimaId",
                table: "Receitas",
                newName: "MateriaPrimaId");

            migrationBuilder.RenameIndex(
                name: "IX_Receitas_salgadoId",
                table: "Receitas",
                newName: "IX_Receitas_SalgadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Receitas_materiaPrimaId",
                table: "Receitas",
                newName: "IX_Receitas_MateriaPrimaId");

            migrationBuilder.RenameColumn(
                name: "materiaPrimaId",
                table: "ItemsMateriaPrima",
                newName: "MateriaPrimaId");

            migrationBuilder.RenameColumn(
                name: "IdPedido",
                table: "ItemsMateriaPrima",
                newName: "IdPedidoFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsMateriaPrima_materiaPrimaId",
                table: "ItemsMateriaPrima",
                newName: "IX_ItemsMateriaPrima_MateriaPrimaId");

            migrationBuilder.RenameColumn(
                name: "IdPedido",
                table: "ItemSalgados",
                newName: "IdPedidoCliente");

            migrationBuilder.AddColumn<int>(
                name: "PedidoFornecedorId",
                table: "ItemsMateriaPrima",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsMateriaPrima_PedidoFornecedorId",
                table: "ItemsMateriaPrima",
                column: "PedidoFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSalgados_IdPedidoCliente",
                table: "ItemSalgados",
                column: "IdPedidoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSalgados_IdSalgado",
                table: "ItemSalgados",
                column: "IdSalgado");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSalgados_PedidosCliente_IdPedidoCliente",
                table: "ItemSalgados",
                column: "IdPedidoCliente",
                principalTable: "PedidosCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSalgados_Salgados_IdSalgado",
                table: "ItemSalgados",
                column: "IdSalgado",
                principalTable: "Salgados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsMateriaPrima_MateriaPrimas_MateriaPrimaId",
                table: "ItemsMateriaPrima",
                column: "MateriaPrimaId",
                principalTable: "MateriaPrimas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsMateriaPrima_PedidoFornecedores_PedidoFornecedorId",
                table: "ItemsMateriaPrima",
                column: "PedidoFornecedorId",
                principalTable: "PedidoFornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_MateriaPrimas_MateriaPrimaId",
                table: "Receitas",
                column: "MateriaPrimaId",
                principalTable: "MateriaPrimas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Salgados_SalgadoId",
                table: "Receitas",
                column: "SalgadoId",
                principalTable: "Salgados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_Receita_Clientes_ClienteId",
                table: "Vendas_Clientes_Receita",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_Receita_PedidosCliente_PedidoClienteId",
                table: "Vendas_Clientes_Receita",
                column: "PedidoClienteId",
                principalTable: "PedidosCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_FornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_PedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                column: "PedidoFornecedorId",
                principalTable: "PedidoFornecedores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSalgados_PedidosCliente_IdPedidoCliente",
                table: "ItemSalgados");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSalgados_Salgados_IdSalgado",
                table: "ItemSalgados");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsMateriaPrima_MateriaPrimas_MateriaPrimaId",
                table: "ItemsMateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsMateriaPrima_PedidoFornecedores_PedidoFornecedorId",
                table: "ItemsMateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_MateriaPrimas_MateriaPrimaId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Salgados_SalgadoId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_Receita_Clientes_ClienteId",
                table: "Vendas_Clientes_Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_Receita_PedidosCliente_PedidoClienteId",
                table: "Vendas_Clientes_Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_Fornecedores_FornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fornecedores_MateriaPrima_PedidoFornecedores_PedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima");

            migrationBuilder.DropIndex(
                name: "IX_ItemsMateriaPrima_PedidoFornecedorId",
                table: "ItemsMateriaPrima");

            migrationBuilder.DropIndex(
                name: "IX_ItemSalgados_IdPedidoCliente",
                table: "ItemSalgados");

            migrationBuilder.DropIndex(
                name: "IX_ItemSalgados_IdSalgado",
                table: "ItemSalgados");

            migrationBuilder.DropColumn(
                name: "PedidoFornecedorId",
                table: "ItemsMateriaPrima");

            migrationBuilder.RenameColumn(
                name: "PedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "pedidoFornecedorId");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "fornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Fornecedores_MateriaPrima_PedidoFornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "IX_Vendas_Fornecedores_MateriaPrima_pedidoFornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Fornecedores_MateriaPrima_FornecedorId",
                table: "Vendas_Fornecedores_MateriaPrima",
                newName: "IX_Vendas_Fornecedores_MateriaPrima_fornecedorId");

            migrationBuilder.RenameColumn(
                name: "PedidoClienteId",
                table: "Vendas_Clientes_Receita",
                newName: "pedidoClienteId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Vendas_Clientes_Receita",
                newName: "clienteId");

            migrationBuilder.RenameColumn(
                name: "IdPedidoCliente",
                table: "Vendas_Clientes_Receita",
                newName: "IdPedido");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Clientes_Receita_PedidoClienteId",
                table: "Vendas_Clientes_Receita",
                newName: "IX_Vendas_Clientes_Receita_pedidoClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_Clientes_Receita_ClienteId",
                table: "Vendas_Clientes_Receita",
                newName: "IX_Vendas_Clientes_Receita_clienteId");

            migrationBuilder.RenameColumn(
                name: "SalgadoId",
                table: "Receitas",
                newName: "salgadoId");

            migrationBuilder.RenameColumn(
                name: "MateriaPrimaId",
                table: "Receitas",
                newName: "materiaPrimaId");

            migrationBuilder.RenameIndex(
                name: "IX_Receitas_SalgadoId",
                table: "Receitas",
                newName: "IX_Receitas_salgadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Receitas_MateriaPrimaId",
                table: "Receitas",
                newName: "IX_Receitas_materiaPrimaId");

            migrationBuilder.RenameColumn(
                name: "MateriaPrimaId",
                table: "ItemsMateriaPrima",
                newName: "materiaPrimaId");

            migrationBuilder.RenameColumn(
                name: "IdPedidoFornecedor",
                table: "ItemsMateriaPrima",
                newName: "IdPedido");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsMateriaPrima_MateriaPrimaId",
                table: "ItemsMateriaPrima",
                newName: "IX_ItemsMateriaPrima_materiaPrimaId");

            migrationBuilder.RenameColumn(
                name: "IdPedidoCliente",
                table: "ItemSalgados",
                newName: "IdPedido");

            migrationBuilder.AddColumn<int>(
                name: "pedidoClienteId",
                table: "ItemSalgados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "salgadoId",
                table: "ItemSalgados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsMateriaPrima_IdPedido",
                table: "ItemsMateriaPrima",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSalgados_pedidoClienteId",
                table: "ItemSalgados",
                column: "pedidoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSalgados_salgadoId",
                table: "ItemSalgados",
                column: "salgadoId");

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
                name: "FK_ItemsMateriaPrima_PedidoFornecedores_IdPedido",
                table: "ItemsMateriaPrima",
                column: "IdPedido",
                principalTable: "PedidoFornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
