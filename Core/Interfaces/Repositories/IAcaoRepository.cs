namespace Core.Interfaces.Repositories
{
    public interface IAcaoRepository
    {
        Task<IEnumerable<PermissaoDto>> ListarAsync(int id);
    }
}