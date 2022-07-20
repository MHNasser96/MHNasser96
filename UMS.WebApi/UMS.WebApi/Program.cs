using System.Configuration;
using System.Reflection;
using MailKit;
using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Serilog;
using Serilog.Events;
using UMS.Application.Entities.Roles.Commands.AddRole;
using UMS.Application.Entities.Roles.Queries.GetRoles;
using UMS.Application.Mappers;
using UMS.Domain.Models;
using UMS.WebApi;
using UMS.WebApi.Middleware;
using UniversitySystem.Pipelines;
using IMailService = UMS.Infrastructure.Abstraction.Services.IMailService;
using MailService = UMS.Infrastructure.Services.MailService;

//
//
// using (var log = new LoggerConfiguration()
//            .WriteTo.Console()
//            .CreateLogger())
// {
//     log.Information("Hello, Serilog!");
//     log.Warning("Goodbye, Serilog.");
// }

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate:"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .Filter.ByExcluding(o=>o.Level.Equals(LogEventLevel.Information))
    //.MinimumLevel.Warning()
    .CreateBootstrapLogger();




var builder = WebApplication.CreateBuilder(args);

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<SessionTime>("SessionTimes");
    return builder.GetEdmModel();
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UmsContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=ums;Username=postgres;Password=123456"));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(GetRolesQuery).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Select().Expand().Count().OrderBy());
builder.Host.UseSerilog();
builder.Services.AddTransient<IMailService,MailService>();


builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseMiddleware<TenantDBContextMiddleware>();

app.MapHub<MessageHub>("/chatHub");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();