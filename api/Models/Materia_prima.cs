using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class MateriaPrima
    {
        [Key]
        public int Id { get; set; }
        public required string produto { get; set; }
        public int quantidade { get; set; }
    }
}
