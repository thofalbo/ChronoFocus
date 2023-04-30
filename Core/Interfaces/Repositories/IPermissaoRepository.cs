namespace Core.Interfaces.Repositories
{
    public interface IPermissaoRepository
    {
        Task<IEnumerable<PermissaoDto>> ListarAsync(int id);
    }
}