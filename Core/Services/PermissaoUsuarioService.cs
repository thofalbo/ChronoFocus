namespace Core.Services
{
    public class PermissaoUsuarioService : IPermissaoUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPermissaoUsuarioRepository _permissaoUsuarioRepository;

        public PermissaoUsuarioService (IUsuarioRepository usuarioRepository, IPermissaoUsuarioRepository permissaoUsuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _permissaoUsuarioRepository = permissaoUsuarioRepository;
        }

        public async Task EditarPermissoesAsync(PermissoesDto permissoes)
        {
            foreach (var permitido in permissoes.Permitidos)
            {
                var permissaoDto = new PermissaoDto
                {
                    IdPermissao = permitido.IdPermissao,
                    IdUsuario = permitido.IdUsuario,
                    TemPermissao = permitido.TemPermissao
                };

                var permissaoUsuario = new PermissaoUsuario
                {
                    IdPermissao = permissaoDto.IdPermissao,
                    IdUsuario = permissaoDto.IdUsuario
                };

                bool temPermissao = await _permissaoUsuarioRepository.ListarAcoesUsuariosAsync(permissaoDto.IdPermissao, permissaoDto.IdUsuario);

                if (!permissaoDto.TemPermissao && temPermissao)
                    await _permissaoUsuarioRepository.ExcluirPermissaoAsync(permissaoUsuario);
                else if (permissaoDto.TemPermissao && !temPermissao)
                    await _permissaoUsuarioRepository.AdicionarPermissaoAsync(permissaoUsuario);
            };
        }
    }
}
