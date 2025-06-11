using Art_Sabores.Models;

namespace Art_Sabores.DTOs
{
    public class GetItemSalgadoDTO
    {
        public int IdSalgado { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
        public SalgadoDTO salgado { get; set; }
    }
}
