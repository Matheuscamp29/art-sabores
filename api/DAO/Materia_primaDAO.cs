using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;

namespace Art_Sabores.DAO
{
    public class Materia_primaDAO : DbContext
    {
        public Materia_primaDAO(DbContextOptions<Materia_primaDAO> options)
            : base(options) { }

        public DbSet<MateriaPrima> MateriasPrimas => Set<MateriaPrima>();
    }
}
