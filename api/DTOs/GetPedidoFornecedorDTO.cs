namespace Art_Sabores.DTOs
{
    public class GetPedidoFornecedorDTO
    {
        public int IdFornecedor{ get; set; }
        public FornecedorDTO? fornecedor { get; set; }
        public List<GetItemMateriaPrimaDTO> Itens { get; set; } = new();
    }
}
