using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class venda_cliente_receita
    {
        [Key]
        public required String NFE { get; set; }
        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }
        [ForeignKey("Carrinho_Cliente")]
        public int Id_Carrinho { get; set; }
        public int subtotal { get; set; }
        public DateTime dateTime { get; set; }
    }
}
