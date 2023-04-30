namespace Web.Controllers;
public class AuthenticatedController : Controller
{
    protected int IdUsuarioLogado { get; set; }
    protected string Rotas { get; set; }
    protected string[] Path { get; set; }
    protected string Rota { get; set; }
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
            Rotas = TokenService.BuscaPermissoes(jwtToken, 2);

            // var Controladores = Rotas.Split("/");

            // Path = Request.Path.Value.Split("/");
            Rota = Request.Path.Value;
            // AcoesProibidas = !Path[2].IsNullOrEmpty() && !Rotas.Contains(Path[2]);
            AcoesProibidas = !Rotas.Contains(Rota);

            // if (!Path[1].IsNullOrEmpty() && !Rotas.Contains(Path[1]))
            //     context.Result = new RedirectResult("/");
            if (AcoesProibidas)
                context.Result = new RedirectResult("/");
                
            // if (!AcoesProibidas)
            //     context.Result = RedirectToAction("");

        }

        if (context.HttpContext.Response.StatusCode == 200)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            context.HttpContext.Response.Headers["Expires"] = "0";
        }
    }
}