using Art_Sabores.DAO;
using Art_Sabores.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;


var builder = WebApplication.CreateBuilder(args);

//.env
Env.Load(); 
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");


//Builder DB

builder.Services.AddDbContext<FornecedorDAO>(options =>
    options.UseSqlServer(connectionString));



//Swager Builder
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

app.MapPost("/api/v1/fornecedor", async (Fornecedor fornecedor, FornecedorDAO dao) =>
{
    dao.Fornecedores.Add(fornecedor);
    await dao.SaveChangesAsync();

    return Results.Created($"/api/v1/fornecedor/{fornecedor.Id}", fornecedor);
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
