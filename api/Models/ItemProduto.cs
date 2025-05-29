using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class ItemProduto
    {
        public int Id { get; set; }
        [ForeignKey("Salgado")]
        public int IdSalgado{get; set;}
        [ForeignKey("VendaSalgadoCliente")]
        public int IdVenda { get; set;}
        public int Quantidade { get; set;}
    }
}
