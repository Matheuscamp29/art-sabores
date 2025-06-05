using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        public required string nome { get; set; }
        public String CNPJ { get; set; }
    }
}
