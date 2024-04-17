using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.Cors;
using RequestPermission.Api.DependencyInjection;
using RequestPermission.Api.Infrastracture;
using RequestPermission.Api.Mapping;
using RequestPermission.Api;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDependencyInjection();

builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddCorsConfiguration();
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

app.UseMiddleware<Middleware>();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
