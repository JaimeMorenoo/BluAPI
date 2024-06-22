# BluAPI
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using swag.Data;
using swag.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración del servicio de base de datos SQLite
builder.Services.AddDbContext<AnonUserDB>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DBConnect")));

// Configuración de servicios adicionales
builder.Services.AddScoped<ICustomerService, customerService>();
builder.Services.AddScoped<ITicketService, TicketService>();

// Configuración de CORS para permitir cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configuración del servicio de autorización
builder.Services.AddAuthorization();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del middleware de desarrollo de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware para permitir CORS
app.UseCors("AllowAnyOrigin");

// Definición de la dirección IP y puerto donde escuchará la API
var ipAddress = "192.168.4.176"; // Cambia esta dirección por la IP de tu máquina
var port = 5033; // Puerto donde escucha tu API

// Configuración del pipeline de solicitud HTTP
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization(); // Middleware de autorización

// Mapeo de los controladores
app.MapControllers();

// Ejecución de la aplicación
app.Run();

// Fin del archivo
