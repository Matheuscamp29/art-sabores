using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
