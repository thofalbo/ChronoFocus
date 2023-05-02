namespace Web.Controllers
{
    [Route("permissao-usuario")]
    public class PermissaoUsuarioController : AuthenticatedController
    {
        private readonly IPermissaoUsuarioService _permissaoUsuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPermissaoRepository _permissaoRepository;
        public PermissaoUsuarioController(IPermissaoUsuarioService permissaoUsuarioService, IPermissaoRepository permissaoRepository, IUsuarioRepository usuarioRepository)
        {
            _permissaoUsuarioService = permissaoUsuarioService;
            _permissaoRepository = permissaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("inicio")]
        public IActionResult Index() => View();

        [HttpGet("cadastrar")]
        public async Task<IActionResult> CadastrarGet(string nome)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioAsync(nome);
            var acoes = await _permissaoRepository.ListarAsync(usuario.Id);
            return View("_cadastrar", acoes);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarPost(PermissoesDto model)
        {
            await _permissaoUsuarioService.EditarPermissoesAsync(model);

            return RedirectToAction("inicio", "permissao-usuario");
        }
    }
}
