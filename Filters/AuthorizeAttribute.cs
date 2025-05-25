using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GSCollect_MVC.Helpers;

namespace GSCollect_MVC.Filters
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Skip authorization for Auth controller
            if (context.Controller.GetType().Name == "AuthController")
            {
                base.OnActionExecuting(context);
                return;
            }

            // Check if user is logged in
            if (!context.HttpContext.Session.IsLoggedIn())
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
