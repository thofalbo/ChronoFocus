namespace Web.Controllers;
public class AuthenticatedController : Controller
{
    protected int IdUsuarioLogado { get; set; }
    protected string Controladores { get; set; }
    protected string Acoes { get; set; }
    protected string Isuarios { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];

        if (string.IsNullOrEmpty(jwtToken))
            context.Result = new RedirectResult("/login/inicio");
        else
        {
            IdUsuarioLogado = TokenService.IdUsuarioLogado(jwtToken);
            Controladores = TokenService.BuscaAcoes(jwtToken, 1);
            Acoes = TokenService.BuscaAcoes(jwtToken, 2);

            var path = Request.Path.Value.Split("/");

            if (!path[1].IsNullOrEmpty() && Controladores.Contains(path[1]))
                context.Result = new RedirectResult("/");
            // else if (!path[2].IsNullOrEmpty() && !Acoes.Contains(path[2]))
            //     context.Result = new RedirectResult("/");
        }

        if (context.HttpContext.Response.StatusCode == 200)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            context.HttpContext.Response.Headers["Expires"] = "0";
        }
    }
}