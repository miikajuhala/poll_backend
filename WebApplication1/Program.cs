using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using WebApplication1.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Telling server to connect to this database on start!
builder.Services.AddDbContext<PollContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PollConnStr")));

Trace.WriteLine("sdsdsdsdsd");

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
