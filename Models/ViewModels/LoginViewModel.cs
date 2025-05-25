// LoginViewModel.cs - DEFINE LOS DATOS DEL FORMULARIO
using System.ComponentModel.DataAnnotations;

namespace GSCollect_MVC.Models.ViewModels
{
    /// <summary>
    /// MODELO DE DATOS PARA EL FORMULARIO DE LOGIN
    /// Piensa en esto como un "molde" que define qué información necesitamos
    /// del usuario para hacer login
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// CAMPO: NOMBRE DE USUARIO
        /// [Required] = Es obligatorio (no puede estar vacío)
        /// [Display] = El texto que aparece en la etiqueta del formulario
        /// </summary>
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// CAMPO: CONTRASEÑA
        /// [DataType(DataType.Password)] = Le dice al navegador que es contraseña
        /// (aparece con asteriscos en lugar del texto real)
        /// </summary>
        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// CAMPO: RECORDAR CONTRASEÑA
        /// Es un checkbox (true = marcado, false = no marcado)
        /// </summary>
        [Display(Name = "Recordar contraseña")]
        public bool RememberMe { get; set; }
    }
}

// ¿CÓMO FUNCIONA ESTO?
// 1. El usuario llena el formulario
// 2. ASP.NET automáticamente convierte los datos del formulario en este objeto
// 3. Podemos usar este objeto en el Controller para procesar el login
