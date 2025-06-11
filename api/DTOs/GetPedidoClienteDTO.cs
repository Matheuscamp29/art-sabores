namespace Art_Sabores.DTOs
{
    public class GetPedidoClienteDTO
    {
        public int IdCliente { get; set; }
        public ClienteDTO cliente { get; set; }

        public List<GetItemSalgadoDTO> Itens { get; set; } = new();
    }
}
