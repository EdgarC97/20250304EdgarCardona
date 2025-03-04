using StudentManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DotNetEnv;
using StudentManagementApi.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Cargar el archivo .env seg�n el entorno
var envFile = builder.Environment.IsDevelopment() ? ".env.local" : ".env.production";
DotNetEnv.Env.Load(envFile);

// Obtener variables de entorno
var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configurar el DbContext con SQL Server, usando la cadena de conexi�n del entorno
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(dbConnection, sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null); // Especifica null para el par�metro opcional
    }));

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Management API", Version = "v1" });
});

var app = builder.Build();

// Aplicar migraciones y ejecutar seeders al iniciar
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

    // Aplica migraciones autom�ticamente
    context.Database.Migrate();

    // Ejecuta seeders solo si no hay estudiantes en la base de datos
    if (!context.Students.Any())
    {
        SeedData.Initialize(context);
    }
}

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1"));
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();