namespace Web.Controllers;
public class AuthenticatedController : Controller
{
    protected int IdUsuarioLogado { get; set; }
    protected string Controladores { get; set; }
    protected string Acoes { get; set; }
    protected string[] Path { get; set; }
    protected bool AcoesProibidas { get; set; }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];

        if (string.IsNullOrEmpty(jwtToken))
            context.Result = new RedirectResult("/login/inicio");
        else
        {
            IdUsuarioLogado = TokenService.IdUsuarioLogado(jwtToken);
            Controladores = TokenService.BuscaPermissoes(jwtToken, 1);
            Acoes = TokenService.BuscaPermissoes(jwtToken, 2);

            Path = Request.Path.Value.Split("/");
            AcoesProibidas = !Path[2].IsNullOrEmpty() && !Acoes.Contains(Path[2]);

            if (!Path[1].IsNullOrEmpty() && !Controladores.Contains(Path[1]))
                context.Result = new RedirectResult("/");
                
            if (!AcoesProibidas)
                context.Result = RedirectToAction("");

        }

        if (context.HttpContext.Response.StatusCode == 200)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            context.HttpContext.Response.Headers["Expires"] = "0";
        }
    }
}