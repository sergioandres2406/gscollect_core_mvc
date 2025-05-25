// HomeController.cs - CONTROLADOR DE LA PÁGINA PRINCIPAL
using System.Diagnostics;
using GSCollect_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using GSCollect_MVC.Helpers;

namespace GSCollect_MVC.Controllers
{
    /// <summary>
    /// CONTROLADOR DE LA PÁGINA PRINCIPAL
    /// Este controlador maneja la página que ve el usuario después de hacer login
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// CONSTRUCTOR
        /// ILogger nos permite escribir mensajes en los logs para debug
        /// </summary>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// ACCIÓN PRINCIPAL - PÁGINA DE INICIO
        /// Esta es la página que se muestra después del login exitoso
        /// </summary>
        public IActionResult Index()
        {
            // VERIFICAR SI HAY USUARIO LOGUEADO
            if (!HttpContext.Session.IsLoggedIn())
            {
                // Si no hay sesión, redirigir al login
                return RedirectToAction("Login", "Auth");
            }

            // PASAR INFORMACIÓN DEL USUARIO A LA VISTA
            // ViewBag es una forma de enviar datos del Controller a la Vista
            ViewBag.LoggedUser = HttpContext.Session.GetLoggedUserName();
            ViewBag.UserGroup = HttpContext.Session.GetUserGroup();
            
            // Mostrar la vista Index.cshtml
            return View();
        }

        /// <summary>
        /// PÁGINA DE PRIVACIDAD (ejemplo)
        /// </summary>
        public IActionResult Privacy()
        {
            // También verificar sesión en otras páginas
            if (!HttpContext.Session.IsLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        /// <summary>
        /// PÁGINA DE ERROR
        /// Se muestra cuando hay errores en la aplicación
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

// ¿CÓMO FUNCIONA ESTO?
// 
// 1. Usuario hace login exitoso en AuthController
// 2. AuthController redirige a Home/Index
// 3. HomeController.Index() verifica si hay sesión
// 4. Si hay sesión: muestra la página principal
// 5. Si no hay sesión: redirige al login
//
// ViewBag: Es como una "mochila" para enviar datos a la vista
// ViewBag.LoggedUser en el Controller = @ViewBag.LoggedUser en la Vista
