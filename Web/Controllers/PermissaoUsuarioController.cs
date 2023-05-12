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

            var permissoes = await _permissaoRepository.ListarAsync(usuario.Id);

            return View("_Editar", permissoes);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> EditarPermissaoUsuarioAsync(PermissoesViewModel permissoes)
        {
            if (!permissoes.IsValid(_notification))
                return Ok(string.Join(", ", _notification.Get()));

            var permitidos = new List<PermissaoUsuario>();
            var negados = new List<PermissaoUsuario>();

            foreach (var permissao in permissoes.Permitidos)
            {
                var usuario = new PermissaoUsuario
                    {
                        IdPermissao = permissao.IdPermissao,
                        IdUsuario = permissao.IdUsuario
                    };

                if (permissao.TemPermissao)
                    permitidos.Add(usuario);
                else
                    negados.Add(usuario);
            }

            await _permissaoUsuarioRepository.EditarPermissoesAsync(permitidos, negados);

            return Ok(string.Join(", ", _notification.Get()));
        }
    }
}
