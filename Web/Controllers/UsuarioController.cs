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
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            return View(usuarios);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View();

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Usuario usuario)
        {
            await _usuarioRepository.CadastrarAsync(new Usuario
            {
                Login = usuario.Login,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCadastro = usuario.DataCadastro.ToUniversalTime()
            });
        }
    }
}