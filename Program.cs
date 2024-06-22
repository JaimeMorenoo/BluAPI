using swag.Models;
using swag.Data;
using Microsoft.EntityFrameworkCore;
using swag.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.WebHost.UseUrls("http://192.168.4.176:5033");

builder.Services.AddDbContext<AnonUserDB>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DBConnect")));



builder.Services.AddScoped<ICustomerService, customerService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.Run(); 
