using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UMS.Application.Entities.Roles.Commands.AddRole;
using UMS.Application.Entities.Roles.Queries.GetRoles;
using UMS.Application.Mappers;
using UMS.Domain.Models;
using UniversitySystem.Pipelines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UmsContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=ums;Username=postgres;Password=123456"));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppLoggingBehaviour<,>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(GetRolesQuery).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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