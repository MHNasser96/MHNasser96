using System.Configuration;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using UMS.Application.Entities.Roles.Commands.AddRole;
using UMS.Application.Entities.Roles.Queries.GetRoles;
using UMS.Application.Mappers;
using UMS.Domain.Models;
using UniversitySystem.Pipelines;


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<SessionTime>("SessionTimes");
    return builder.GetEdmModel();
}

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
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Select().Expand().Count().OrderBy());


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