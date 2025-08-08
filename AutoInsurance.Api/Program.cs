using AutoInsurance.Api.Configurations;
using AutoInsurance.Api.Endpoints;
using AutoInsurance.Application.Services;
using AutoInsurance.Domain.Repositories;
using AutoInsurance.Infrastructure;
using AutoInsurance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection String
var conn = builder.Configuration.GetConnectionString("AutoInsuranceDbConnection");

// Database Context
builder.Services.AddDbContext<AutoInsuranceDbContext>(options =>
    options.UseSqlite(conn));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperConfig>());

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// AutoInsurance.API/Program.cs
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddScoped<PolicyService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPolicyEndpoints();

app.Run();