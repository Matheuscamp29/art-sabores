using Art_Sabores.DAO;
using Art_Sabores.Models;
using Art_Sabores.DTOs;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

//.env
Env.Load(); 
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");


//Builder DB

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



//Swager Builder
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

//Fornecedor CRUD

//Incluir Fornecedor
app.MapPost("/api/v1/fornecedor", async (Fornecedor fornecedor, AppDbContext dao) =>
{
    dao.Fornecedores.Add(fornecedor);
    await dao.SaveChangesAsync();

    return Results.Created($"/api/v1/fornecedor/{fornecedor.Id}", fornecedor);
});

//Mostra os Fornecedores
app.MapGet("/api/v1/getFornecedores", async (AppDbContext dao) => 
    await dao.Fornecedores.ToListAsync());

//Atualizar Fornecedor
app.MapPut("/api/v1/updateFornecedor/{id}", async (int id, Fornecedor input, AppDbContext dao) =>
{
    var fornecedor = await dao.Fornecedores.FindAsync(id);
    if (fornecedor is null)
        return Results.NotFound("Fornecedor n�o encontrado.");

    // Atualize as propriedades que deseja modificar
    fornecedor.nome = input.nome;

    await dao.SaveChangesAsync();
    return Results.Ok(fornecedor);
});

//Delete Fornecedor
app.MapDelete("/api/v1/deleteFornecedor/{id}", async (int id, AppDbContext dao) =>
{
    var fornecedor = await dao.Fornecedores.FindAsync(id);
    if (fornecedor is null)
        return Results.NotFound("Fornecedor n�o encontrado.");

    dao.Fornecedores.Remove(fornecedor);
    await dao.SaveChangesAsync();

    return Results.Ok($"Fornecedor com ID {id} deletado com sucesso.");
});

// CRUD Salgado

// Incluir Salgado
app.MapPost("/api/v1/salgado", async (Salgado salgado, AppDbContext dao) =>
{
    dao.Salgados.Add(salgado);
    await dao.SaveChangesAsync();

    return Results.Created($"/api/v1/salgado/{salgado.Id}", salgado);
});

// Listar todos os Salgados
app.MapGet("/api/v1/getSalgados", async (AppDbContext dao) =>
    await dao.Salgados.ToListAsync());

// Atualizar Salgado
app.MapPut("/api/v1/updateSalgado/{id}", async (int id, Salgado input, AppDbContext dao) =>
{
    var salgado = await dao.Salgados.FindAsync(id);
    if (salgado is null)
        return Results.NotFound("Salgado não encontrado.");

    salgado.Nome = input.Nome;
    salgado.Preco = input.Preco;
    salgado.Estoque = input.Estoque;

    await dao.SaveChangesAsync();
    return Results.Ok(salgado);
});

// Deletar Salgado
app.MapDelete("/api/v1/deleteSalgado/{id}", async (int id, AppDbContext dao) =>
{
    var salgado = await dao.Salgados.FindAsync(id);
    if (salgado is null)
        return Results.NotFound("Salgado não encontrado.");

    dao.Salgados.Remove(salgado);
    await dao.SaveChangesAsync();

    return Results.Ok($"Salgado com ID {id} deletado com sucesso.");
});


// CRUD Cliente

// Incluir Cliente
app.MapPost("/api/v1/cliente", async (Cliente cliente, AppDbContext dao) =>
{
    dao.Clientes.Add(cliente);
    await dao.SaveChangesAsync();
    return Results.Created($"/api/v1/cliente/{cliente.Id}", cliente);
});

// Listar todos os Clientes
app.MapGet("/api/v1/getClientes", async (AppDbContext dao) =>
    await dao.Clientes.ToListAsync());

// Atualizar Cliente
app.MapPut("/api/v1/updateCliente/{id}", async (int id, Cliente input, AppDbContext dao) =>
{
    var cliente = await dao.Clientes.FindAsync(id);
    if (cliente is null)
        return Results.NotFound("Cliente não encontrado.");

    cliente.Nome = input.Nome;
    cliente.Telefone = input.Telefone;

    await dao.SaveChangesAsync();
    return Results.Ok(cliente);
});

// Deletar Cliente
app.MapDelete("/api/v1/deleteCliente/{id}", async (int id, AppDbContext dao) =>
{
    var cliente = await dao.Clientes.FindAsync(id);
    if (cliente is null)
        return Results.NotFound("Cliente não encontrado.");

    dao.Clientes.Remove(cliente);
    await dao.SaveChangesAsync();

    return Results.Ok($"Cliente com ID {id} deletado com sucesso.");
});



//Materia prima CRUD

// Incluir Materia_Prima
app.MapPost("/api/v1/materia_prima", async (MateriaPrima materia, AppDbContext dao) =>
{
    dao.Add(materia);
    await dao.SaveChangesAsync();

    return Results.Created($"/api/v1/materia_prima/{materia.Id}", materia);
});

// Listar todas as Materias_Primas
app.MapGet("/api/v1/getMateriasPrimas", async (AppDbContext dao) => 
    await dao.MateriaPrimas.ToListAsync());

// Atualizar Materia_Prima
app.MapPut("/api/v1/updateMateriaPrima/{id}", async (int id, MateriaPrima input, AppDbContext dao) =>
{
    var materia = await dao.MateriaPrimas.FindAsync(id);
    if (materia is null)
        return Results.NotFound("Matéria-prima não encontrada.");

    // Atualizar o campo desejado
    materia.Estoque = input.Estoque;

    await dao.SaveChangesAsync();
    return Results.Ok(materia);
});

// Deletar Materia_Prima
app.MapDelete("/api/v1/deleteMateriaPrima/{id}", async (int id, AppDbContext dao) =>
{
    var materia = await dao.MateriaPrimas.FindAsync(id);
    if (materia is null)
        return Results.NotFound("Matéria-prima não encontrada.");

    dao.MateriaPrimas.Remove(materia);
    await dao.SaveChangesAsync();

    return Results.Ok($"Matéria-prima com ID {id} deletada com sucesso.");
});



//CRUD Pedido Salgado

app.MapPost("/api/v1/PedidoCliente/fechar", async (PedidoClienteDTO dto, AppDbContext dao) =>
{
    var pedido = new PedidoCliente();
    dao.PedidosCliente.Add(pedido);
    await dao.SaveChangesAsync();

    foreach (var item in dto.Itens)
    {
        dao.ItemSalgados.Add(new ItemSalgado
        {
            IdSalgado = item.IdSalgado,
            IdPedidoCliente = pedido.Id,
            Quantidade = item.Quantidade
        });
    }
    await dao.SaveChangesAsync();

    var nota = new NotaFiscalCliente
    {
        NFE = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
        dateTime = DateTime.Now,
        IdCliente = dto.IdCliente,
        IdPedidoCliente = pedido.Id
    };
    dao.Vendas_Clientes_Receita.Add(nota);

    await dao.SaveChangesAsync();

    return Results.Ok(new { PedidoId = pedido.Id, NotaFiscal = nota.NFE });
});

app.MapGet("api/v1/PedidoCliente/get", async (AppDbContext dao) =>
{
    var notasFiscais = await dao.Vendas_Clientes_Receita
    .Include(n => n.Cliente)
    .Include(n => n.PedidoCliente)
        .ThenInclude(p => p.Itens)
        .ThenInclude(s => s.Salgado)
     .ToListAsync();
    var resultado = notasFiscais.Select(nota => new GetPedidoClienteDTO
    {
        cliente = new ClienteDTO
        {
            Id = nota.Cliente.Id,
            Nome = nota.Cliente.Nome
        },
        Itens = nota.PedidoCliente.Itens.Select(item => new GetItemSalgadoDTO
        {
            salgado = new SalgadoDTO
            {
                Nome = item.Salgado.Nome,
                Preco = item.Salgado.Preco
            },
            Quantidade = item.Quantidade,
            Subtotal = item.Quantidade * item.Salgado.Preco
        }).ToList()
    }).ToList();
    return Results.Ok(resultado);
});

//app.MapGet("/api/v1/getClientes", async (AppDbContext dao) =>
  //  await dao.Clientes.ToListAsync());

app.MapDelete("/api/v1/PedidoCliente/deletar/{id}", async (int id, AppDbContext dao) =>
{
    var pedido = await dao.PedidosCliente.FindAsync(id);
    if (pedido == null) 
        Results.NotFound("Pedido não encontrado.");

    var itens = dao.ItemSalgados.Where(i => i.IdPedidoCliente == id);
    dao.ItemSalgados.RemoveRange(itens);

    var nota = await dao.Vendas_Clientes_Receita.FirstOrDefaultAsync(n => n.IdPedidoCliente == id);
    if (nota != null)
        dao.Vendas_Clientes_Receita.Remove(nota);

    dao.PedidosCliente.Remove(pedido);

    await dao.SaveChangesAsync();

    return Results.Ok("Pedidos e relacionados deletados com sucesso");
});



//CRUD Pedido Fornecedor
app.MapPost("/api/v1/PedidoFornecedor/fechar", async (PedidoFornecedorDTO dto, AppDbContext dao) =>
{
    var pedido = new PedidoFornecedor();
    dao.PedidoFornecedores.Add(pedido);
    await dao.SaveChangesAsync();

    foreach (var item in dto.Itens)
    {
        dao.ItemsMateriaPrima.Add(new ItemMateriaPrima
        {
            IdMateriaPrima = item.IdMateriaPrima,
            IdPedidoFornecedor = pedido.Id,
            Quantidade = item.Quantidade
        });
    }
    await dao.SaveChangesAsync();

    var nota = new NotaFiscalFornecedor
    {
        NFE = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
        dateTime = DateTime.Now,
        IdFornecedor = dto.IdFornecedor,
        IdPedido = pedido.Id
    };
    dao.Vendas_Fornecedores_MateriaPrima.Add(nota);

    await dao.SaveChangesAsync();

    return Results.Ok(new { PedidoId = pedido.Id, NotaFiscal = nota.NFE });

});


app.MapGet("api/v1/PedidoFornecedor/get", async (AppDbContext dao) =>
{
    var notasFiscais = await dao.Vendas_Fornecedores_MateriaPrima
    .Include(n => n.Fornecedor)
    .Include(n => n.PedidoFornecedor)
        .ThenInclude(p => p.Itens)
        .ThenInclude(m => m.MateriaPrima)
     .ToListAsync();
    var resultado = notasFiscais.Select(nota => new GetPedidoFornecedorDTO
    {
        fornecedor = new FornecedorDTO
        {
            Id = nota.Fornecedor.Id,
            Nome = nota.Fornecedor.nome,
            CNPJ = nota.Fornecedor.CNPJ
        },
        Itens = nota.PedidoFornecedor.Itens.Select(item => new GetItemMateriaPrimaDTO
        {
            materiaPrima = new MateriaPrimaDTO
            {
                Nome = item.MateriaPrima.Nome
            },
            Quantidade = item.Quantidade
        }).ToList()
    }).ToList();
    return Results.Ok(resultado);
});

app.MapDelete("/api/v1/PedidoFornecedor/deletar/{id}", async (int id, AppDbContext dao) =>
{
    var pedido = await dao.PedidoFornecedores.FindAsync(id);
    if (pedido == null)
        Results.NotFound("Pedido não encontrado.");

    var itens = dao.ItemsMateriaPrima.Where(i => i.IdPedidoFornecedor == id);
    dao.ItemsMateriaPrima.RemoveRange(itens);

    var nota = await dao.Vendas_Fornecedores_MateriaPrima.FirstOrDefaultAsync(n => n.IdPedido == id);
    if (nota != null)
        dao.Vendas_Fornecedores_MateriaPrima.Remove(nota);

    dao.PedidoFornecedores.Remove(pedido);

    await dao.SaveChangesAsync();

    return Results.Ok("Pedidos e relacionados deletados com sucesso");
});





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
