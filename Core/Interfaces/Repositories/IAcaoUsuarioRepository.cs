namespace Core.Interfaces.Repositories
{
    public interface IAcaoUsuarioRepository
    {
        Task<IEnumerable<AcaoUsuario>> ListarAsync();
        Task<IEnumerable<AcaoUsuario>> ListarPorFuncionarioAsync(string nome);
        Task EditarPermissoesAsync(IEnumerable<AcaoUsuario> permitidos);
    }
}