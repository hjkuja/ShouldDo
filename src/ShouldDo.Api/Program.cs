using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ShouldDo.Api.Endpoints;
using ShouldDo.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("Database")
                       ?? throw new InvalidOperationException("Connection string not found.");

builder.Services
    .AddDatabase(connectionString)
    .AddApplicationServices();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("ShouldDo API")   
            .WithTheme(ScalarTheme.Alternate);
    });
}

app.UseHttpsRedirection();

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ShouldDo.Application.Database.TodoContext>();
if (!dbContext.Database.CanConnect())
{
    throw new ApplicationException("Database not available");
}

await dbContext.Database.MigrateAsync();

app.Run();