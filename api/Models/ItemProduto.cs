using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class ItemProduto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Salgado")]
        public int IdSalgado{get; set;}
        [ForeignKey("PedidoCliente")]
        public int IdPedido { get; set;}
        public int Quantidade { get; set;}
    }
}
