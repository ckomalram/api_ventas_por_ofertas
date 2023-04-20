using System.Text.Json.Serialization;
using api_ventas_por_oferta.Core.Context;
using api_ventas_por_oferta.Core.Dto;
using api_ventas_por_oferta.Core.Interfaces;
using api_ventas_por_oferta.Core.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// .AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conf cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsRule", rule =>
    {
        // rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://mipagina.com");
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});


//conf automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// conf ef
builder.Services.AddSqlServer<BienesContext>(builder.Configuration.GetConnectionString("cnbuscobienes"));

//TODO: Inyectar servicios
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPatioService, PatioService>();
builder.Services.AddScoped<IAutoService, AutoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsRule");


app.UseAuthorization();

app.MapControllers();

app.Run();
