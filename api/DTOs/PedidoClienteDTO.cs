namespace Art_Sabores.DTOs
{
    public class PedidoClienteDTO
    {
            public int IdCliente { get; set; }
            public List<ItemSalgadoDTO> Itens { get; set; } = new();
    }
}
