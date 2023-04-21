namespace Web.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly AppSettings _appSettings;

        public LoginController(IUsuarioRepository usuarioRepository, AppSettings appSettings)
        {
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }

        [HttpGet("inicio")]
        public IActionResult Index() => View();

        [HttpPost("autenticar")]
        public async Task<ActionResult> Autenticar(Usuario model)
        {
            var usuario = await _usuarioRepository.Get(model.Login, model.Senha);

            if (usuario == null)
                return NotFound("Usuário ou senha inválidos");

            var jwtToken = TokenService.GenerateToken(usuario, _appSettings.Chave.Segredo);

            Response.Cookies.Append("ChronoFocusAuthenticationToken", jwtToken);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("ChronoFocusAuthenticationToken");

            return RedirectToAction("Index", "login");
        }
        
        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View("_cadastrar");

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Usuario usuario) => await _usuarioRepository.CadastrarAsync(usuario);

        [HttpGet("cadastrado")]
        public IActionResult Cadastrado() => View("_cadastrado");
    }
}