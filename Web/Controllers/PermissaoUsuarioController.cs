namespace Web.Controllers
{
    [Route("permissao-usuario")]
    public class PermissaoUsuarioController : AuthenticatedController
    {
        private readonly IPermissaoUsuarioRepository _permissaoUsuarioRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly Notification _notification;
        public PermissaoUsuarioController (
            IPermissaoUsuarioRepository permissaoUsuarioRepository,
            IPermissaoRepository permissaoRepository,
            IUsuarioRepository usuarioRepository,
            Notification notification
            )
        {
            _permissaoUsuarioRepository = permissaoUsuarioRepository;
            _permissaoRepository = permissaoRepository;
            _usuarioRepository = usuarioRepository;
            _notification = notification;
        }

        [HttpGet("inicio")]
        public IActionResult Index() => View();

        [HttpGet("editar")]
        public async Task<IActionResult> MostrarViewCadastrarPermissaoUsuarioAsync(PermissaoUsuarioViewModel usuarioViewModel)
        {
            if (!usuarioViewModel.IsValid(_notification))
                return BadRequest(string.Join(", ", _notification.Get()));
                
            var usuario = await _usuarioRepository.BuscarUsuarioAsync(usuarioViewModel.Nome);

            var permissoes = await _permissaoRepository.BuscarPermissoesPorUsuarioAsync(usuario.Id);

            if (!permissoes.Any())
                return BadRequest(string.Join(", ", _notification.Get()));

            return View("_Editar", permissoes);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> EditarPermissaoUsuarioAsync(IEnumerable<PermissaoDto> permitidos)
        {
            await _permissaoUsuarioRepository.EditarPermissoesAsync(permitidos);

            return Ok(string.Join(", ", _notification.Get()));
        }
    }
}
