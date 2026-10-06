using Microsoft.EntityFrameworkCore;
using ControleDeFinancasPessoais.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Banco de Dados (InMemory para testes rápidos ou SQLite/SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FinancasDb"));

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();