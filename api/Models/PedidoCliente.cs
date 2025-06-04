using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class PedidoCliente
    {
        [Key]
        public int Id { get; set; }
        public int Subtotal { get; set; }
        [ForeignKey("ItemProduto")]
        public int IdItem { get; set; }
    }
}
