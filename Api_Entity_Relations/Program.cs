using Api_Entity_Relations.Context;
using Api_Entity_Relations.Models;
using Api_Entity_Relations.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//Inyeccion de dependecias
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<PrincipalContext>(options => options.UseNpgsql(connectionString));

//CONTEXTOS

builder.Services.AddScoped < IRepository<Parent>, Repository<Parent>>();
builder.Services.AddScoped<IRepository<Child>, Repository<Child>>();

//JSON Ignore
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

//MIGRACION PARA LA BD
/*using (var scope = app.Services.CreateScope()) 
{
    var context = scope.ServiceProvider.GetRequiredService<PrincipalContext>();
    context.Database.Migrate();
}*/


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
