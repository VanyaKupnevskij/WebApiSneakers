using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApiSneakers.Controllers;
using WebApiSneakers.Database;
using WebApiSneakers.Models;
using WebApiSneakers.Repositories.Implimentations;
using WebApiSneakers.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IBaseRepository<Product>, BaseRepository<Product>>();
builder.Services.AddTransient<OrderRepository, OrderRepository>();
builder.Services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddTransient<IBaseRepository<ChangePrice>, BaseRepository<ChangePrice>>();
builder.Services.AddTransient<FavoriteRepository, FavoriteRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .WithOrigins("*"));

app.Run();
