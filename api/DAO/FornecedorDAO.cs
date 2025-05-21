using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
namespace Art_Sabores.DAO
{
    public class FornecedorDAO: DbContext
    {
        public FornecedorDAO(DbContextOptions<FornecedorDAO> options)
            : base(options) { }

        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();

    }
}
