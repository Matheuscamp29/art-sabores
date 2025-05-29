using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class VendaFornecedorMateria
    {
        public int Id { get; set; }
        [ForeignKey("ItemProduto")]
        public int ItemProdutoId { get; set; }
        public String NFSe { get; set; }
        
    }
}
