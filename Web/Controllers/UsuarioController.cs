namespace Web.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(
            ApplicationDbContext dbContext,
            IUsuarioRepository usuarioRepository
        )
        {
            _dbContext = dbContext;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var jwtToken = HttpContext.Session.GetString("JwtToken");            
            return jwtToken.IsNullOrEmpty()
                ? RedirectToAction("Index", "Login")
                : View(await _dbContext.Usuarios.ToListAsync());

        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var jwtToken = HttpContext.Session.GetString("JwtToken");
            return jwtToken.IsNullOrEmpty()
                ? RedirectToAction("Index", "Login")
                : View();
        }

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Usuario usuario) => await _usuarioRepository.CadastrarAsync(usuario);

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var obj = await _dbContext.Usuarios.FindAsync(id.Value);
            
            return View(obj);
        }
        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            var obj = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Usuarios.Remove(obj);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}