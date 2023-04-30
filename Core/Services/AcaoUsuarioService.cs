namespace Core.Services
{
    public class AcaoUsuarioService : IAcaoUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAcaoUsuarioRepository _acaoUsuarioRepository;

        public AcaoUsuarioService (IUsuarioRepository usuarioRepository, IAcaoUsuarioRepository acaoUsuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _acaoUsuarioRepository = acaoUsuarioRepository;
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

                var acaoUsuarios = await _acaoUsuarioRepository.ListarAcoesUsuariosAsync(acaoDto.IdAcao, acaoDto.IdUsuario);

                if (!acaoDto.TemPermissao && acaoUsuarios)
                    await _acaoUsuarioRepository.ExcluirPermissaoAsync(acaoUsuario);
                else if (acaoDto.TemPermissao && !acaoUsuarios)
                    await _acaoUsuarioRepository.AdicionarPermissaoAsync(acaoUsuario);
            };
        }
    }
}
