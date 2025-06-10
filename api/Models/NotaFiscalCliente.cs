using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class NotaFiscalCliente
    {
        [Key]
        public required String NFE { get; set; }
        public DateTime dateTime { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        [ForeignKey("PedidoCliente")]
        public int IdPedido { get; set; }
    }
}
