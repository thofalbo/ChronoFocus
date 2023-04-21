namespace Web.Controllers
{
    public class AuthenticatedController : Controller
    {
        public int IdUsuarioLogado { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];
            

            if (string.IsNullOrEmpty(jwtToken))
                context.Result = new RedirectResult("/login/inicio");
            else {
                IdUsuarioLogado = TokenService.UsuarioLogado(jwtToken);
                ViewBag.IdUsuarioLogado = IdUsuarioLogado;
            }

            if (context.HttpContext.Response.StatusCode == 200)
            {
                context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                context.HttpContext.Response.Headers["Pragma"] = "no-cache";
                context.HttpContext.Response.Headers["Expires"] = "0";
            }
        }
    }
}