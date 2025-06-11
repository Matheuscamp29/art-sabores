using Art_Sabores.Models;

namespace Art_Sabores.DTOs
{
    public class ItemMateriaPrimaDTO
    {
        public int IdMateriaPrima { get; set; }
        public int Quantidade { get; set; }

        public MateriaPrimaDTO MateriaPrima { get; set; }
    }
}
