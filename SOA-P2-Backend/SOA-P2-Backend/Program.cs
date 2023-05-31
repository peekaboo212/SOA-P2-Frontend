using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Repository.Context;
using Service.IServices;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

Console.WriteLine("******************************   CONFIGURANDO SERVICIOS    *******************************");

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddTransient<IActivo, ActivoService>();
builder.Services.AddTransient<IActivo_Employee, Activo_EmployeeService>();
builder.Services.AddTransient<IEmail, EmailService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("******************************   SERVICIOS CONFIGURADOS    *******************************");

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
await Migrations(scope.ServiceProvider);

app.Run();

async Task Migrations(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetService<ApplicationDbContext>();
    var conn_appdb = context.Database.GetDbConnection();

    Console.WriteLine($"Conexión Actual AppDB: {conn_appdb.ToString()}  {Environment.NewLine}   {conn_appdb.ConnectionString}");
    Console.WriteLine("******************************   PROBANDO ACCESO    *******************************");

    try
    {
        Console.WriteLine("DB Disponible de Identity: " + context.Database.CanConnect());
        context.Database.Migrate();
    }
    catch (Exception e)
    {
        Console.WriteLine($"------- !! ERROR connectando: {e.Message}");
    }
}
