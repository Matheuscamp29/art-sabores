using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class NotaFiscalCliente
    {
        [Key]
        public required String NFE { get; set; }
        public DateTime dateTime { get; set; }
        [ForeignKey(nameof(Models.Cliente))]
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey(nameof(Models.PedidoCliente))]
        public int IdPedidoCliente { get; set; }
        public PedidoCliente? PedidoCliente { get; set; }
    }
}
