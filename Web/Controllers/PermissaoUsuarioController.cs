namespace Web.Controllers
{
    [Route("permissao-usuario")]
    public class PermissaoUsuarioController : AuthenticatedController
    {
        private readonly IPermissaoUsuarioService _permissaoUsuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly Notification _notification;
        public PermissaoUsuarioController (
            IPermissaoUsuarioService permissaoUsuarioService,
            IPermissaoRepository permissaoRepository,
            IUsuarioRepository usuarioRepository,
            Notification notification
            )
        {
            _permissaoUsuarioService = permissaoUsuarioService;
            _permissaoRepository = permissaoRepository;
            _usuarioRepository = usuarioRepository;
            _notification = notification;
        }

        [HttpGet("inicio")]
        public IActionResult Index() => View();

        [HttpGet("cadastrar")]
        public async Task<IActionResult> MostrarViewCadastrarPermissaoUsuarioAsync(PermissaoUsuarioViewModel usuarioViewModel)
        {
            if (!usuarioViewModel.IsValid(_notification))
                return BadRequest(string.Join(", ", _notification.Get()));
                
            var usuario = await _usuarioRepository.BuscarUsuarioAsync(usuarioViewModel.Nome);

            var acoes = await _permissaoRepository.ListarAsync(usuario.Id);

            return View("_cadastrar", acoes);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarPermissaoUsuarioAsync(PermissoesDto model)
        {
            await _permissaoUsuarioService.EditarPermissoesAsync(model);

            return RedirectToAction("inicio", "permissao-usuario");
        }
    }
}
