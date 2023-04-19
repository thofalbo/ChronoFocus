namespace Web.Controllers
{
    [Route("usuario")]
    public class UsuarioController : AuthenticatedController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(ApplicationDbContext dbContext, IUsuarioRepository usuarioRepository)
        {
            _dbContext = dbContext;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index() => View(await _dbContext.Usuarios.ToListAsync());

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id) => View(await _dbContext.Usuarios.FindAsync(id.Value));

        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _usuarioRepository.ExcluirAsync(id);

            return RedirectToAction("Index");
        }
    }
}