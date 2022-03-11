using Microsoft.EntityFrameworkCore;
using backEnd.Models;

var builder = WebApplication.CreateBuilder(args);
var CorsConfiguration = "_corsConfiguration";

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Contexto>
    (options => options.UseMySql("server=localhost;initial catalog=logindb;uid=root;password=wml096",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsConfiguration,
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

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

app.UseCors(CorsConfiguration);

app.Run();
