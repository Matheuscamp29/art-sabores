using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class venda_fornecedor_materiaPrima
    {
        [Key]
        public required String NFE { get; set; }
        [ForeignKey("Fornecedor")]
        public int Id_Fornecedor { get; set; }
        [ForeignKey("Carrinho_MP")]
        public int Id_Carrinho { get; set; }
        public int subtotal { get; set; }
        public DateTime dateTime { get; set; }
    }
}
