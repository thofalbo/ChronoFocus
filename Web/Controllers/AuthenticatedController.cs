namespace Web.Controllers;
public class AuthenticatedController : Controller
{
    public int IdUsuarioLogado { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];

        if (string.IsNullOrEmpty(jwtToken))
            context.Result = new RedirectResult("/login/inicio");
        else
        {
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

// namespace Web.Controllers;
// public class AuthenticatedController : Controller
// {
//     public int IdUsuarioLogado { get; set; }

//     public override void OnActionExecuting(ActionExecutingContext context)
//     {
//         base.OnActionExecuting(context);

//         var jwtToken = Request.Cookies["ChronoFocusAuthenticationToken"];

//         if (string.IsNullOrEmpty(jwtToken))
//         {
//             context.Result = new RedirectResult("/login/inicio");
//         }
//         else
//         {
//             IdUsuarioLogado = TokenService.UsuarioLogado(jwtToken);
//             ViewBag.IdUsuarioLogado = IdUsuarioLogado;

//             var tela = context.RouteData.Values["controller"].ToString();
//             var opcao = context.RouteData.Values["action"].ToString();

//             if (!CheckUserAccess(IdUsuarioLogado, tela, opcao))
//             {
//                 context.Result = new ForbidResult();
//             }
//         }

//         if (context.HttpContext.Response.StatusCode == 200)
//         {
//             context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
//             context.HttpContext.Response.Headers["Pragma"] = "no-cache";
//             context.HttpContext.Response.Headers["Expires"] = "0";
//         }
//     }

//     private bool CheckUserAccess(int idUsuario, string tela, string opcao)
//     {
//         // Here you can implement your logic to check if the user has access to the current route
//         // You can use the provided database tables to do that

//         return true; // Return true if the user has access, false otherwise
//     }
// }