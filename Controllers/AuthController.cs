// AuthController.cs - EL CEREBRO DEL LOGIN
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSCollect_MVC.Models;
using GSCollect_MVC.Models.ViewModels;
using GSCollect_MVC.Helpers;

namespace GSCollect_MVC.Controllers
{
    /// <summary>
    /// CONTROLADOR DE AUTENTICACIÓN
    /// Un controlador es como un "despachador" que recibe peticiones
    /// y decide qué hacer con ellas
    /// </summary>
    public class AuthController : Controller
    {
        /// <summary>
        /// CONEXIÓN A LA BASE DE DATOS
        /// _context nos permite acceder a todas las tablas de la BD
        /// </summary>
        private readonly GscollectContext _context;

        /// <summary>
        /// CONSTRUCTOR DEL CONTROLADOR
        /// ASP.NET automáticamente nos da la conexión a la BD cuando crea este controlador
        /// Esto se llama "Dependency Injection" (Inyección de Dependencias)
        /// 
        /// ¿Cómo funciona?
        /// 1. ASP.NET ve que necesitamos GscollectContext
        /// 2. Busca en Program.cs donde registramos el DbContext
        /// 3. Nos lo pasa automáticamente
        /// </summary>
        public AuthController(GscollectContext context)
        {
            _context = context;
        }

        // ========================================
        // MÉTODO 1: MOSTRAR LA PANTALLA DE LOGIN
        // ========================================
        
        /// <summary>
        /// ACCIÓN PARA MOSTRAR LA PANTALLA DE LOGIN (GET)
        /// 
        /// ¿Cuándo se ejecuta?
        /// Cuando el usuario escribe: localhost:5000/Auth/Login
        /// 
        /// [HttpGet] significa: "Este método responde cuando cargan la página"
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            // PASO 1: Verificar si ya hay alguien logueado
            if (HttpContext.Session.IsLoggedIn())
            {
                // Si ya está logueado, mandarlo a la página principal
                // RedirectToAction = "Ve a otro Controller y Action"
                return RedirectToAction("Index", "Home");
            }

            // PASO 2: Crear un modelo vacío para el formulario
            var model = new LoginViewModel();

            // PASO 3: Verificar si hay una cookie de "recordar contraseña"
            var loginCookie = Request.Cookies[SessionHelper.COOKIE_LOGIN];
            
            if (!string.IsNullOrEmpty(loginCookie))
            {
                try
                {
                    // PASO 4: Leer la cookie (formato: UserName=valor&Password=valor)
                    var parts = loginCookie.Split('&');
                    if (parts.Length == 2)
                    {
                        var userPart = parts[0].Split('=');
                        var passPart = parts[1].Split('=');

                        if (userPart.Length == 2 && passPart.Length == 2 && 
                            userPart[0] == "UserName" && passPart[0] == "Password")
                        {
                            // Solo prellenamos el usuario, no la contraseña (por seguridad)
                            model.UserName = userPart[1];
                            model.RememberMe = true;
                        }
                    }
                }
                catch
                {
                    // Si hay error leyendo la cookie, simplemente la ignoramos
                }
            }

            // PASO 5: Mostrar la pantalla de login
            // View(model) = "Muestra la vista Login.cshtml con estos datos"
            return View(model);
        }

        // ========================================
        // MÉTODO 2: PROCESAR EL LOGIN
        // ========================================
        
        /// <summary>
        /// ACCIÓN PARA PROCESAR EL LOGIN (POST)
        /// 
        /// ¿Cuándo se ejecuta?
        /// Cuando el usuario llena el formulario y hace clic en "Entrar"
        /// 
        /// [HttpPost] significa: "Este método responde cuando envían un formulario"
        /// [ValidateAntiForgeryToken] = Protección contra ataques CSRF
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // PASO 1: Verificar que los datos del formulario sean válidos
            if (!ModelState.IsValid)
            {
                // Si hay errores (campos vacíos, etc.), mostrar la pantalla otra vez
                return View(model);
            }

            try
            {
                // PASO 2: Validar los datos (misma validación que la app vieja)
                if (!ValidateInput(model.UserName) || !ValidateInput(model.Password))
                {
                    ModelState.AddModelError("", "Información no válida, intente nuevamente.");
                    return View(model);
                }

                // PASO 3: Buscar el usuario en la base de datos
                // async/await = "Esta operación puede tomar tiempo, espera sin bloquear"
                var user = await _context.Users
                    .Where(u => u.UserName.Trim() == model.UserName.Trim() && 
                               u.Password.Trim() == model.Password.Trim())
                    .FirstOrDefaultAsync();

                // PASO 4: Verificar si encontramos el usuario
                if (user != null)
                {
                    // ¡LOGIN EXITOSO!
                    
                    // PASO 5: Guardar los datos del usuario en la sesión
                    HttpContext.Session.SetUserSession(user.UserId, user.FullName, user.UserGroupId);

                    // PASO 6: Manejar la cookie "Recordar contraseña"
                    if (model.RememberMe)
                    {
                        // Crear cookie con formato igual a la app vieja
                        var cookieValue = $"UserName={model.UserName}&Password={model.Password}";
                        Response.Cookies.Append(SessionHelper.COOKIE_LOGIN, cookieValue, new CookieOptions
                        {
                            Expires = DateTime.Now.AddYears(1),  // Expira en 1 año
                            HttpOnly = false // Para que JavaScript pueda leerla (igual que app vieja)
                        });
                    }
                    else
                    {
                        // Si no marcó "recordar", borrar cookie existente
                        Response.Cookies.Delete(SessionHelper.COOKIE_LOGIN);
                    }

                    // PASO 7: Redirigir a la página principal
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // LOGIN FALLÓ - usuario o contraseña incorrectos
                    ModelState.AddModelError("", "Error: el Usuario o la Contraseña no es válido.");
                }
            }
            catch (Exception)
            {
                // Si hay algún error técnico, mostrar mensaje genérico
                ModelState.AddModelError("", "Información no válida, intente nuevamente.");
            }

            // Si llegamos aquí, algo salió mal, mostrar la pantalla otra vez
            return View(model);
        }

        // ========================================
        // MÉTODO 3: CERRAR SESIÓN
        // ========================================
        
        /// <summary>
        /// ACCIÓN PARA CERRAR SESIÓN (LOGOUT)
        /// ¿Cuándo se ejecuta? Cuando el usuario hace clic en "Cerrar Sesión"
        /// </summary>
        public IActionResult Logout()
        {
            // PASO 1: Limpiar la sesión
            HttpContext.Session.ClearUserSession();
            
            // PASO 2: Borrar la cookie de "recordar contraseña"
            Response.Cookies.Delete(SessionHelper.COOKIE_LOGIN);
            
            // PASO 3: Redirigir al login
            return RedirectToAction("Login");
        }

        // ========================================
        // MÉTODO PRIVADO: VALIDAR ENTRADA
        // ========================================
        
        /// <summary>
        /// MÉTODO PARA VALIDAR ENTRADA (igual que la app vieja)
        /// Evita caracteres especiales que podrían causar problemas
        /// </summary>
        private bool ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            // Mismos caracteres prohibidos que la app vieja
            var invalidChars = new[] { "%", "'", "(", ")", "*" };
            return !invalidChars.Any(input.Contains);
        }
    }
}

// ¿CÓMO FUNCIONA TODO ESTO JUNTO?
// 
// 1. Usuario escribe: localhost:5000
// 2. Program.cs dice: "Ve a Auth/Login"
// 3. Se ejecuta AuthController.Login() [HttpGet]
// 4. Se muestra Login.cshtml
// 5. Usuario llena formulario y hace clic "Entrar"
// 6. Se ejecuta AuthController.Login(model) [HttpPost]
// 7. Se valida contra la base de datos
// 8. Si es correcto: sesión + redirección a Home
// 9. Si es incorrecto: mostrar error
