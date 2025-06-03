using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class Materia_Prima
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int quantidade { get; set;}
    }
}
