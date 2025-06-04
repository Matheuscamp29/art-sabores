
﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Sabores.Models
{
    public class Receita //Lista relação de matéria prima e salgado, registra rendimento
    {
        public int Id { get; set; }

        public int QuantidadeMatPrim { get; set; }
        public required String unidade {  get; set; }
        public bool FlagConstante { get; set; }
        public int Rendimento { get; set; }
        [ForeignKey("Materia_prima")]
        public int IdMateriaPrima { get; set; }
        [ForeignKey("Salgado")]
        public int IdSalgado { get; set; }


    }
}
