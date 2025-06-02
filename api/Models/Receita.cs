using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public float quantMatPri { get; set; }
        public String unidadeMG { get; set; }
        public bool constante { get; set; }
        public int rendimento { get; set; }
        [ForeignKey("Materia_prima")]
        public int IdMateriaPrima { get; set; }
        [ForeignKey("Salgado")]
        public int IdSalgado {  get; set; }


    }

    //quando um salgado for produzido 

    //aumenta o numero 
    //dele no estoque 

    //e reduz a quantidade de materia prima
    //q foi utilizado no estoque
}
