using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebDiaryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaj obsługę endpointów i Swaggera
builder.Services.AddControllers();               // ← jeśli używasz kontrolerów
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();      // ← potrzebne do Swaggera
builder.Services.AddSwaggerGen();                // ← generuje dokumentację

var app = builder.Build();

// Middleware Swaggera – tylko w Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();            // generuje openapi.json
    app.UseSwaggerUI();         // uruchamia Swagger UI pod /swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // ← dla [ApiController] i kontrolerów

app.Run();