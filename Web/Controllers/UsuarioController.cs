namespace Web.Controllers;
[Route("usuario")]
public class UsuarioController : AuthenticatedController
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet("inicio")]
    public async Task<IActionResult> Index() => View(await _usuarioRepository.BuscarUsuariosAsync());

    [HttpGet("excluir")]
    public async Task<IActionResult> Excluir(int id) => View("_excluir", await _usuarioRepository.BuscarUsuarioAsync(new Usuario { Id = id }));

    [HttpPost("excluir")]
    public async Task<IActionResult> ExcluirUsuario(int id)
    {
        await _usuarioRepository.ExcluirAsync(id);

        return RedirectToAction("Index");
    }
}