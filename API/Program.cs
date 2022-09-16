using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EkoshipContext>(opt =>
    opt.UseInMemoryDatabase("Ekoship"));
builder.Services.AddScoped<IDataRepository<User>, UserRepository>();
builder.Services.AddScoped<IDataRepository<TodoItem>, TodoItemRepository>();
builder.Services.AddScoped<IService<UserDTO, User>, UserService>();
builder.Services.AddScoped<IService<TodoItemDTO, TodoItem>, TodoItemService>();
builder.Services.AddScoped<DatabaseScope, DatabaseScope>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "EkoshipApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EkoshipApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();