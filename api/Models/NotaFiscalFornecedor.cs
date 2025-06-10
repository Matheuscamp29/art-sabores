using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class NotaFiscalFornecedor
    {
        [Key]
        public required String NFE { get; set; }
        public DateTime dateTime { get; set; }
        [ForeignKey("Fornecedor")]
        public int Id_Fornecedor { get; set; }
        [ForeignKey("PedidoFornecedor")]
        public int IdPedido { get; set; }
    }
}
