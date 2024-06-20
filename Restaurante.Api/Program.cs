using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Application.Services;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Repositories;
using Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPedidoService, PedidoService>();


// AddDbContext configuration
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Registro de los repositorios
builder.Services.AddScoped<IRepository<Empleado>, EmpleadoRepository>();
builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<Menu>, MenuRepository>();
builder.Services.AddScoped<IRepository<Mesa>, MesaRepository>();
builder.Services.AddScoped<IRepository<Pedido>, PedidoRepository>();
builder.Services.AddScoped<IRepository<DetallePedido>, DetallePedidoRepository>();
builder.Services.AddScoped<IRepository<Factura>, FacturaRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


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
