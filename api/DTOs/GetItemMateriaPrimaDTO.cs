namespace Art_Sabores.DTOs
{
    public class GetItemMateriaPrimaDTO
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public MateriaPrimaDTO materiaPrima { get; set; }
    }
}
