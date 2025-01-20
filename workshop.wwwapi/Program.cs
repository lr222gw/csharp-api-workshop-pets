using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Validators;
using FluentValidation;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IRepository, PetRepository>();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Pets"));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(PetPostValidator));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.ConfigurePetEndpoint();

app.Run();

