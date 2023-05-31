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

var proveedor = builder.Services.BuildServiceProvider();

builder.Services.AddCors(opciones =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
    opciones.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
await Migrations(scope.ServiceProvider);

// Agregar la tarea recurrente
var timer = new Timer(PrintTest, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));
/*// Agregar la tarea recurrente para ejecutar PrintTest todos los d�as a las 8 am
var now = DateTime.Now;
var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);

if (now > nextRunTime)
{
    nextRunTime = nextRunTime.AddDays(1);
}

var timeUntilNextRun = nextRunTime - now;

var timer = new System.Timers.Timer(timeUntilNextRun.TotalMilliseconds);
timer.Elapsed += async (sender, e) =>
{
    await PrintTest(sender);
    timer.Interval = TimeSpan.FromDays(1).TotalMilliseconds;
};
timer.Start();*/

app.Run();

async Task Migrations(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetService<ApplicationDbContext>();
    var conn_appdb = context.Database.GetDbConnection();

    Console.WriteLine($"Conexi�n Actual AppDB: {conn_appdb.ToString()}  {Environment.NewLine}   {conn_appdb.ConnectionString}");
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

/*async Task PrintTest(object sender)
{
    Console.WriteLine("Enviando correo de recordatorio");
    var activoEmployeeService = scope.ServiceProvider.GetRequiredService<IActivo_Employee>();

    activoEmployeeService.GetAllUndeliveredSendNotification();
}*/

void PrintTest(object state)
{
    Console.WriteLine("Enviando correo de recordatorio");
    var activoEmployeeService = scope.ServiceProvider.GetRequiredService<IActivo_Employee>();

    activoEmployeeService.GetAllUndeliveredSendNotification();
}
