using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class PedidoFornecedor
    {
        [Key]
        public int Id { get; set; }
        public int Subtotal { get; set; }
        [ForeignKey("ItemMateriaPrima")]
        public int IdItem { get; set; }
    }
}
