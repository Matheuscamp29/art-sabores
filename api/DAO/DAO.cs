using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
namespace Art_Sabores.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
        public DbSet<Materia_Prima> Materia_Primas => Set<Materia_Prima>();
        public DbSet<Salgado> Salgados => Set<Salgado>();
        public DbSet<Producao> Producaos => Set<Producao>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Estoque> Estoques => Set<Estoque>();
    }
}
