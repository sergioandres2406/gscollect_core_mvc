// SessionHelper.cs - AYUDANTE PARA MANEJAR SESIONES
namespace GSCollect_MVC.Helpers
{
    /// <summary>
    /// HELPER PARA MANEJAR SESIONES DE USUARIO
    /// Las sesiones son como "cajas de memoria" donde guardamos información
    /// del usuario mientras navega por la aplicación
    /// </summary>
    public static class SessionHelper
    {
        // ========================================
        // CONSTANTES: NOMBRES DE LAS VARIABLES DE SESIÓN
        // ========================================
        // Estos son los "nombres de las cajas" donde guardamos información
        
        public const string SESSION_USER_NAME = "LoggedUser";     // Guarda el nombre completo
        public const string SESSION_USER_GROUP = "UserGroup";     // Guarda el grupo del usuario  
        public const string SESSION_USER_ID = "UserId";           // Guarda el ID del usuario
        public const string COOKIE_LOGIN = "GSCollect_Login";     // Nombre de la cookie

        /// <summary>
        /// MÉTODO PARA GUARDAR DATOS DEL USUARIO EN LA SESIÓN
        /// Cuando el login es exitoso, guardamos la información del usuario aquí
        /// 
        /// ¿Cómo funciona?
        /// 1. Recibe los datos del usuario (ID, nombre, grupo)
        /// 2. Los guarda en la sesión con nombres específicos
        /// 3. Ahora podemos acceder a esta información desde cualquier página
        /// </summary>
        public static void SetUserSession(this ISession session, int userId, string fullName, int userGroupId)
        {
            // "this ISession session" significa que podemos usar:
            // HttpContext.Session.SetUserSession(id, name, group)
            
            session.SetInt32(SESSION_USER_ID, userId);        // Guardar ID del usuario
            session.SetString(SESSION_USER_NAME, fullName);   // Guardar nombre completo
            session.SetInt32(SESSION_USER_GROUP, userGroupId); // Guardar grupo
        }

        /// <summary>
        /// MÉTODO PARA VERIFICAR SI HAY UN USUARIO LOGUEADO
        /// Devuelve true si alguien está logueado, false si no
        /// 
        /// ¿Cómo funciona?
        /// 1. Busca si existe el nombre de usuario en la sesión
        /// 2. Si existe = hay alguien logueado
        /// 3. Si no existe = nadie está logueado
        /// </summary>
        public static bool IsLoggedIn(this ISession session)
        {
            return session.GetString(SESSION_USER_NAME) != null;
        }

        /// <summary>
        /// MÉTODO PARA OBTENER EL NOMBRE DEL USUARIO LOGUEADO
        /// Lo usamos para mostrar "Bienvenido Juan Pérez" en la pantalla
        /// </summary>
        public static string? GetLoggedUserName(this ISession session)
        {
            return session.GetString(SESSION_USER_NAME);
        }

        /// <summary>
        /// MÉTODO PARA OBTENER EL ID DEL USUARIO LOGUEADO
        /// </summary>
        public static int? GetLoggedUserId(this ISession session)
        {
            return session.GetInt32(SESSION_USER_ID);
        }

        /// <summary>
        /// MÉTODO PARA OBTENER EL GRUPO DEL USUARIO
        /// Lo usaremos después para permisos (qué puede hacer cada usuario)
        /// </summary>
        public static int? GetUserGroup(this ISession session)
        {
            return session.GetInt32(SESSION_USER_GROUP);
        }

        /// <summary>
        /// MÉTODO PARA LIMPIAR LA SESIÓN (LOGOUT)
        /// Borra todos los datos del usuario cuando hace logout
        /// </summary>
        public static void ClearUserSession(this ISession session)
        {
            session.Remove(SESSION_USER_ID);
            session.Remove(SESSION_USER_NAME);
            session.Remove(SESSION_USER_GROUP);
        }
    }
}

// ¿CÓMO FUNCIONA ESTO EN LA PRÁCTICA?
// 
// GUARDAR SESIÓN (después del login exitoso):
// HttpContext.Session.SetUserSession(123, "Juan Pérez", 1);
//
// VERIFICAR SI ESTÁ LOGUEADO:
// if (HttpContext.Session.IsLoggedIn()) { /* hacer algo */ }
//
// OBTENER NOMBRE:
// string nombre = HttpContext.Session.GetLoggedUserName();
//
// LIMPIAR SESIÓN (logout):
// HttpContext.Session.ClearUserSession();
