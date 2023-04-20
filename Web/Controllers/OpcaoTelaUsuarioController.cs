namespace Web.Controllers
{
    [Route("opcao-tela-usuario")]
    public class OpcaoTelaUsuarioController : AuthenticatedController
    {
        public OpcaoTelaUsuarioController(
        )
        {
        }

        [HttpGet("index")]
        public IActionResult Index() => View();
    }
}