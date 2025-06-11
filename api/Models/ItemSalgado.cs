using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class ItemSalgado
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Models.Salgado))]
        public int IdSalgado{get; set;}
        public Salgado? Salgado { get; set; }
        [ForeignKey(nameof(Models.PedidoCliente))]
        public int IdPedidoCliente { get; set;}
        public PedidoCliente? PedidoCliente { get; set; }
        public int Quantidade { get; set;}
    }
}
