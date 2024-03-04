using Dapper_CRUD_ASP.Net_core_SQL_Server.Data;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Infrastructure.Generic;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Infrastructure.IGeneric;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddScoped<DapperDBContext>();
builder.Services.AddScoped<ISuperHero<SuperHero>, Superheroes>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
