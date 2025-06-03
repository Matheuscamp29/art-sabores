using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public int QuantidadeMP { get; set; }
        public String? unidade {  get; set; }
        public bool Flag { get; set; }
        public int Rendimento { get; set; }
        [ForeignKey("Materia_prima")]
        public int IdMateriaPrima { get; set; }

        public int IdSalgado { get; set; }
    }
}
