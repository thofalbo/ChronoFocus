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
            // no controler pra ja chegar certo
            /*
            permissoes.Permitidos.Select(x => new PermissaoUsuario
            {

            });
            */

            // buscar as permissoes antes do for



            foreach (var permitido in permissoes.Permitidos)
            {
                var permissaoUsuario = new PermissaoUsuario
                {
                    IdPermissao = permitido.IdPermissao,
                    IdUsuario = permitido.IdUsuario
                };

                bool temPermissao = await _permissaoUsuarioRepository.ListarAcoesUsuariosAsync(permitido.IdPermissao, permitido.IdUsuario);

                if (!permitido.TemPermissao && temPermissao)
                    await _permissaoUsuarioRepository.ExcluirPermissaoAsync(permissaoUsuario);
                else if (permitido.TemPermissao && !temPermissao)
                    await _permissaoUsuarioRepository.AdicionarPermissaoAsync(permissaoUsuario);
            };
        }
    }
}
