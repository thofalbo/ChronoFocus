namespace Core.Services
{
    public class AcaoUsuarioService : IAcaoUsuarioService
    {
        private readonly IAcaoRepository _acaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAcaoUsuarioRepository _acaousuarioRepository;

        public AcaoUsuarioService(
            IAcaoRepository acaoRepository,
            IUsuarioRepository usuarioRepository,
            IAcaoUsuarioRepository acaoUsuarioRepository
        )
        {
            _acaoRepository = acaoRepository;
            _usuarioRepository = usuarioRepository;
            _acaousuarioRepository = acaoUsuarioRepository;
        }

        public async Task EditarPermissoesAsync(PermissoesDto permissoes)
        {
            foreach (var permitido in permissoes.Permitidos)
            {
                var acaoDto = new PermitidoDto
                {
                    IdAcao = permitido.IdAcao,
                    IdUsuario = permitido.IdUsuario,
                    TemPermissao = permitido.TemPermissao
                };

                var acaoUsuario = new AcaoUsuario
                {
                    IdAcao = acaoDto.IdAcao,
                    IdUsuario = acaoDto.IdUsuario
                };

                if (acaoDto.TemPermissao == false)
                    await _acaousuarioRepository.ExcluirPermissaoAsync(acaoUsuario);
                else
                    await _acaousuarioRepository.AdicionarPermissaoAsync(acaoUsuario);
            };
        }
    }
}
