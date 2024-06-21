using swag.Models;
using swag.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnonUserDB>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DBConnect")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AnonUserDB>();
    if (dbContext.Database.CanConnect())
    {
        Console.WriteLine("Database connection successful!");
    }
    else
    {
        Console.WriteLine("Database connection failed.");
    }
}

app.UseHttpsRedirection();
app.Run(); 
