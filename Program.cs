global using RPG.Models;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registering DataBase Context
builder.Services.AddDbContext<DataContext>(connection => connection.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Manually Added
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Scope for that , CharacterService Provides implementaion
builder.Services.AddScoped<ICharacterService,CharacterService>();

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

app.Run();
