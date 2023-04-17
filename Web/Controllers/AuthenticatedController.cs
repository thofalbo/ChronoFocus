using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Controllers
{
    public class AuthenticatedController : Controller
    {
        public int IdUsuarioLogado { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var jwtToken = Request.Cookies["JwtToken"];

            if (string.IsNullOrEmpty(jwtToken))
            {
                context.Result = new RedirectResult("/Login");
            }
            else
            {
                IdUsuarioLogado = TokenService.UsuarioLogado(jwtToken);
            }
        }
    }
}