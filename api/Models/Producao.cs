namespace Art_Sabores.Models
{
    public class Producao
    {
        public int Id { get; set; }
        public string? NomeSalgado { get; set; }
        public float quantMatPri { get; set; }

    }

    //quando um salgado for produzido 

    //aumenta o numero 
    //dele no estoque 

    //e reduz a quantidade de materia prima
    //q foi utilizado no estoque
}
