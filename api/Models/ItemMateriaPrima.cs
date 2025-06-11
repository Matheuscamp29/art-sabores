using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Art_Sabores.Models
{
    public class ItemMateriaPrima
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Models.MateriaPrima))]
        public int IdMateriaPrima { get; set; }
        public MateriaPrima? MateriaPrima { get; set; }
        [ForeignKey(nameof(Models.PedidoFornecedor))]
        public int IdPedidoFornecedor { get; set; }
        public PedidoFornecedor? PedidoFornecedor { get; set; }
        public int Quantidade { get; set; }
    }
}
