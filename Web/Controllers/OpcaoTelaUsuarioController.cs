namespace Web.Controllers;
[Route("opcao-tela-usuario")]
public class OpcaoTelaUsuarioController : AuthenticatedController
{
    private readonly IOpcaoTelaUsuarioRepository _opcaoTelaUsuarioRepository;
    public OpcaoTelaUsuarioController(
        IOpcaoTelaUsuarioRepository opcaoTelaUsuarioRepository
    )
    {
        _opcaoTelaUsuarioRepository = opcaoTelaUsuarioRepository;
    }
    [HttpGet("inicio")]
    public IActionResult Index() => View();

    [HttpPost("cadastrar")]
    public async Task CadastrarOpcaoTelaUsuario(OpcaoTelaUsuario opcaoTelaUsuario) => await _opcaoTelaUsuarioRepository.CadastrarAsync(opcaoTelaUsuario);
}