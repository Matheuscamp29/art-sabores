using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class Salgado
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; } 
        public float Preco { get; set; }
        public int Estoque { get; set; }
    }
}
