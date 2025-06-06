﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Art_Sabores.Models
{
    public class ItemMateriaPrima
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MateriaPrima")]
        public int IdMateriaPrima { get; set; }
        [ForeignKey("PedidoFornecedor")]
        public int IdPedido{ get; set; }
        public int Quantidade { get; set; }
    }
}
