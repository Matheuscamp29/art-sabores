namespace Art_Sabores.DTOs
{
    public class PedidoFornecedorDTO
    {
        public int IdFornecedor { get; set; }
        public List<ItemMateriaPrimaDTO> Itens { get; set; } = new();
    }
}
