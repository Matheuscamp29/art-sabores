using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
namespace Art_Sabores.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
        public DbSet<MateriaPrima> MateriaPrimas => Set<MateriaPrima>();
        public DbSet<Salgado> Salgados => Set<Salgado>();
        public DbSet<Receita> Receitas => Set<Receita>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<ItemMateriaPrima> ItemsMateriaPrima => Set<ItemMateriaPrima>();
        public DbSet<ItemSalgado> ItemProdutos => Set<ItemSalgado>();
        public DbSet<PedidoCliente> PedidosCliente => Set<PedidoCliente>();
        public DbSet<PedidoFornecedor> PedidoFornecedores => Set<PedidoFornecedor>();
        public DbSet<NotaFiscalCliente> Vendas_Clientes_Receita => Set<NotaFiscalCliente>();
        public DbSet<NotaFiscalFornecedor> Vendas_Fornecedores_MateriaPrima => Set<NotaFiscalFornecedor>();
    }

    public class NotaFiscalFornecedor
    {
    }

    public class NotaFiscalCliente
    {
    }

    public class MateriaPrima
    {
    }
}
