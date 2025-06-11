using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.DTOs
{
    public class SalgadoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
