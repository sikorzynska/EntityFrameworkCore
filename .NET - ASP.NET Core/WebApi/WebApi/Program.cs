using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Data;
using WebApi.Data.Repositories;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<TODODbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    //.LogTo(message => File.AppendAllText(Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\..\logs.txt"), message)));

builder.Services.AddScoped<DbInitializer>();
builder.Services.AddScoped<ITODORepository, TODORepository>();

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

using (app)
{
    await app.InitializeDbContext();
    await app.RunAsync();
}
