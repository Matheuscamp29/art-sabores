using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
namespace Art_Sabores.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
        public DbSet<Materia_Prima> MateriaPrimas => Set<Materia_Prima>();
        public DbSet<Salgado> Salgados => Set<Salgado>();
        public DbSet<Receita> Receitas => Set<Receita>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<ItemMateriaPrima> ItemsMateriaPrima => Set<ItemMateriaPrima>();
        public DbSet<ItemProduto> ItemProdutos => Set<ItemProduto>();
        public DbSet<PedidoCliente> PedidosCliente => Set<PedidoCliente>();
        public DbSet<PedidoFornecedor> PedidoFornecedores => Set<PedidoFornecedor>();
        public DbSet<venda_cliente_receita> Vendas_Clientes_Receita => Set<venda_cliente_receita>();
        public DbSet<venda_fornecedor_materiaPrima> Vendas_Fornecedores_MateriaPrima => Set<venda_fornecedor_materiaPrima>();
    }
}
