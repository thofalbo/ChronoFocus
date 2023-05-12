namespace Core.Interfaces.Repositories
{
    public interface IPermissaoUsuarioRepository
    {
        Task<IEnumerable<PermissaoUsuario>> ListarAsync();
        Task<IEnumerable<PermissaoUsuario>> ListarPorFuncionarioAsync(string nome);
        Task ExcluirPermissaoAsync(PermissaoUsuario permissao);
        Task AdicionarPermissaoAsync(PermissaoUsuario permissao);
        Task<bool> ListarAcoesUsuariosAsync(int idPermissao, int idUsuario);
        Task EditarPermissoesAsync(IEnumerable<PermissaoUsuario> permitidos, IEnumerable<PermissaoUsuario> negados);
    }
}
