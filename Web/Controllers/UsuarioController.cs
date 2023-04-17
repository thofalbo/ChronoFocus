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
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Usuarios.ToListAsync());
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View();

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Usuario usuario) => await _usuarioRepository.CadastrarAsync(usuario);

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id.Value);
            return View(usuario);
        }

        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _usuarioRepository.ExcluirAsync(id);

            return RedirectToAction("Index");
        }
    }
}