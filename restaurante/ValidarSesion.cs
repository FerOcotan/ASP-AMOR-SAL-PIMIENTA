using System;

public class restaurante.ValidarSesion
{
    public class ValidarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {

                filterContext.Result = new RedirectResult("~/UsuarioLogin/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
