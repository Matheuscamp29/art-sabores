using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
namespace Art_Sabores.DAO
{
    public class DAO : DbContext
    {
        public DAO(DbContextOptions<DAO> options)
            : base(options) { }

        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
        public DbSet<MateriaPrima> MateriaPrima => Set<MateriaPrima>();

    }
}
