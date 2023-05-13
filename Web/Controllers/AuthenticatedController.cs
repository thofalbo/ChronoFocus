namespace Web.Controllers
{
    public class AuthenticatedController : Controller
    {
        protected int IdUsuarioLogado { get; set; }
        protected string[] Rotas { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];

            if (string.IsNullOrEmpty(jwtToken))
                context.Result = new RedirectResult("/login/inicio");
            else
            {
                IdUsuarioLogado = TokenService.IdUsuarioLogado(jwtToken);
                Rotas = TokenService.BuscaPermissoes(jwtToken, 2).Split(',');

                if (!Rotas.Any(rota => Request.Path.Value.StartsWith(rota)))
                    context.Result = new RedirectResult("/Home/Error");
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
