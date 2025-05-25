// Program.cs - EL CORAZÓN DE LA APLICACIÓN
using Microsoft.EntityFrameworkCore;
using GSCollect_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// PASO 1: REGISTRAR SERVICIOS
// ========================================
// Esto es como "preparar las herramientas" antes de construir una casa

// 🔧 SERVICIO 1: MVC (Model-View-Controller)
// Le dice a la aplicación: "Vas a usar el patrón MVC"
builder.Services.AddControllersWithViews();

// 🔧 SERVICIO 2: BASE DE DATOS
// Le dice a la aplicación: "Vas a conectarte a SQL Server"
builder.Services.AddDbContext<GscollectContext>(options =>
    // Lee la conexión desde appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 SERVICIO 3: SESIONES (Para recordar quién está logueado)
// Primero necesita un lugar en memoria para guardar las sesiones
builder.Services.AddDistributedMemoryCache();

// Luego configura las sesiones
builder.Services.AddSession(options =>
{
    // Tiempo que dura la sesión sin actividad (10 horas como la app vieja)
    options.IdleTimeout = TimeSpan.FromMinutes(600);  
    
    // Solo el servidor puede leer las cookies (seguridad)
    options.Cookie.HttpOnly = true;
    
    // Las cookies son esenciales para el funcionamiento
    options.Cookie.IsEssential = true;
});

// ========================================
// PASO 2: CONSTRUIR LA APLICACIÓN
// ========================================
var app = builder.Build();

// ========================================
// PASO 3: CONFIGURAR EL "PIPELINE" (Flujo de peticiones)
// ========================================
// Esto es el orden en que se procesan las peticiones

// Si estamos en producción, maneja errores elegantemente
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Servir archivos estáticos (CSS, JavaScript, imágenes)
app.UseStaticFiles();

// Habilitar el sistema de rutas (URLs)
app.UseRouting();

// ¡IMPORTANTE! Habilitar sesiones (debe ir después de UseRouting)
app.UseSession();

// Sistema de autorización
app.UseAuthorization();

// ========================================
// PASO 4: CONFIGURAR LA RUTA PRINCIPAL
// ========================================
// Cuando alguien escribe "localhost:5000", ¿a dónde va?
app.MapControllerRoute(
    name: "default",
    // Patrón: /Controller/Action/Id
    // Si no especifica nada, va a Auth/Login
    pattern: "{controller=Auth}/{action=Login}/{id?}");

// ========================================
// PASO 5: INICIAR LA APLICACIÓN
// ========================================
app.Run();
