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
    }
}
