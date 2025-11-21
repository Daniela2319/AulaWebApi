using AulaWebApi.Infra.Context;
using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;
using AulaWebApi.Services;
using AulaWebApi.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEndLocal",
    policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
            .AllowAnyMethod()   // permite qualquer método (GET, POST, PUT, DELETE...)
            .AllowAnyHeader();  // permite qualquer header
    });
});

//Database OrganizerContext
builder.Services.AddDbContext<OrganizerContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Postgres");
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(BaseController<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontEndLocal");

app.UseAuthorization();

app.MapControllers();

app.Run();
