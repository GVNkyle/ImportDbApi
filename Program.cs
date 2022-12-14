using API._Repositories.Interfaces;
using API._Repositories.Repositories;
using ImportDbApi._Services.Interfaces;
using ImportDbApi._Services.Services;
using ImportDbApi.Data;
using ImportDbApi.Helpers.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AsposeUtility.Install();

var connection = "DbConnection";

// Add services to the container.
builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString(connection)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryAccessor, RepositoryAccessor>();

builder.Services.AddScoped<IService, Service>();

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
