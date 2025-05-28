using Art_Sabores.DAO;
using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;


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
        return Results.NotFound("Fornecedor não encontrado.");

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
        return Results.NotFound("Fornecedor não encontrado.");

    dao.Fornecedores.Remove(fornecedor);
    await dao.SaveChangesAsync();

    return Results.Ok($"Fornecedor com ID {id} deletado com sucesso.");
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
