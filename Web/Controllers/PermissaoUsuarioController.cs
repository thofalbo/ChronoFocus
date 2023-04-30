namespace Web.Controllers
{
    [Route("permissao-usuario")]
    public class PermissaoUsuarioController : AuthenticatedController
    {
        private readonly IPermissaoUsuarioService _permissaoUsuarioService;
        private readonly IPermissaoRepository _permissaoRepository;
        public PermissaoUsuarioController(IPermissaoUsuarioService permissaoUsuarioService, IPermissaoRepository permissaoRepository)
        {
            _permissaoUsuarioService = permissaoUsuarioService;
            _permissaoRepository = permissaoRepository;
        }

        [HttpGet("inicio")]
        public IActionResult Index() => View();

        [HttpGet("cadastrar")]
        public async Task<IActionResult> CadastrarGet()
        {
            var acoes = await _permissaoRepository.ListarAsync(1);
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
