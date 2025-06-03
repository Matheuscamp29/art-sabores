<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations.Schema;
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> b068cbdd072d413a148a06ccd6efef705d3e7726

namespace Art_Sabores.Models
{
    public class Receita
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public int QuantidadeMP { get; set; }
        public String? unidade {  get; set; }
        public bool Flag { get; set; }
        public int Rendimento { get; set; }
        [ForeignKey("Materia_prima")]
        public int IdMateriaPrima { get; set; }

        public int IdSalgado { get; set; }
    }
=======
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
>>>>>>> b068cbdd072d413a148a06ccd6efef705d3e7726
}
