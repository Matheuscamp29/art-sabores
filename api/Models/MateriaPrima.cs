using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class MateriaPrima
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int Estoque { get; set;}
    }
}
