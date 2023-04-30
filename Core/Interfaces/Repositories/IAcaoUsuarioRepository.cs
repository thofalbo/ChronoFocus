namespace Core.Interfaces.Repositories
{
    public interface IAcaoUsuarioRepository
    {
        Task<IEnumerable<AcaoUsuario>> ListarAsync();
        Task<IEnumerable<AcaoUsuario>> ListarPorFuncionarioAsync(string nome);
        Task ExcluirPermissaoAsync(AcaoUsuario permissao);
        Task AdicionarPermissaoAsync(AcaoUsuario permissao);
        Task<bool> ListarAcoesUsuariosAsync(int idAcao, int idUsuario);
    }
}
