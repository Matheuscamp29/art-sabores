
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class Receita //Lista relação de matéria prima e salgado, registra rendimento
    {
        [Key]
        public int Id { get; set; }

        public int QuantidadeMatPrim { get; set; }
        public required String unidade {  get; set; }
        public bool FlagConstante { get; set; }
        public int Rendimento { get; set; }

        [ForeignKey(nameof(Models.MateriaPrima))]
        public int IdMateriaPrima { get; set; }
        public MateriaPrima? MateriaPrima { get; set; }
        [ForeignKey(nameof(Models.Salgado))]
        public int IdSalgado { get; set; }
        public Salgado? Salgado { get; set; }

    }
}
