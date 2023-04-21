namespace Web.Controllers
{
    [Route("opcao-tela-usuario")]
    public class OpcaoTelaUsuarioController : AuthenticatedController
    {
        public OpcaoTelaUsuarioController(
        )
        {
        }
        [HttpGet("inicio")]
        public IActionResult Index() => View();
    }
}