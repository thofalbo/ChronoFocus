namespace Web.Controllers;
[Route("usuario")]
public class UsuarioController : AuthenticatedController
{
    private readonly AppDbContext _dbContext;
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(AppDbContext dbContext, IUsuarioRepository usuarioRepository)
    {
        _dbContext = dbContext;
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet("inicio")]
    public async Task<IActionResult> Index() => View(await _dbContext.Usuarios.ToListAsync());

    [HttpGet("excluir")]
    public async Task<IActionResult> Excluir(int id) => View("_excluir", await _dbContext.Usuarios.FindAsync(id));

    [HttpPost("excluir")]
    public async Task<IActionResult> ExcluirUsuario(int id)
    {
        await _usuarioRepository.ExcluirAsync(id);

        return RedirectToAction("Index");
    }
}