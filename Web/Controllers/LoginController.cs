namespace Web.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly AppSettings _appSettings;
        public LoginController(
            IUsuarioRepository usuarioRepository,
            AppSettings appSettings
        )
        {
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }

        [HttpGet("index")]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            var usuario = UsuarioRepository.Get(model.Login, model.Senha);

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuario, _appSettings.Chave.Segredo);

            usuario.Senha = "";
            
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
