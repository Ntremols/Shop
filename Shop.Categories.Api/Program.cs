
using Microsoft.EntityFrameworkCore;
using Shop.Categories.Domain.Interfaces;
using Shop.Categories.Persistence.Context;
using Shop.Categories.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connstring = builder.Configuration.GetConnectionString("ShopContext");



builder.Services.AddDbContext<ShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

// add dependency objeto de datos
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
