using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class PedidoCliente
    {
        [Key]
        public int Id { get; set; }
        public ICollection<ItemSalgado>? Itens { get; set; }
    }
}
