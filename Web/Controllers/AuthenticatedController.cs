namespace Web.Controllers;
public class AuthenticatedController : Controller
{
    protected int IdUsuarioLogado { get; set; }
    protected string acoes { get; set; }
    protected string controladores { get; set; }
    protected string usuarios { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];

        controladores = TokenService.BuscaAcoes(jwtToken);
        var permitidos = controladores.Split(",");

        // RouteData.Values["action"].ToString() != usuario
        if (string.IsNullOrEmpty(jwtToken) || RouteData.Values["controller"].ToString() == "login" )
            context.Result = new RedirectResult("/login/inicio");
        else
        {
            IdUsuarioLogado = TokenService.IdUsuarioLogado(jwtToken);
            acoes = TokenService.BuscaAcoes(jwtToken);

            // ViewBag.IdUsuarioLogado = IdUsuarioLogado;
            // ViewBag.Acoes = acoes;
            // ViewBag.Controladores = controladores;
            // ViewBag.usuarios = usuarios;
            ViewBag.controller = RouteData.Values["action"].ToString();
        }

        if (context.HttpContext.Response.StatusCode == 200)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            context.HttpContext.Response.Headers["Expires"] = "0";
        }
    }
}