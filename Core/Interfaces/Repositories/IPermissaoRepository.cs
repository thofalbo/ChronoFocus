namespace Core.Interfaces.Repositories
{
    public interface IPermissaoRepository
    {
        Task<IEnumerable<PermissaoDto>> BuscarPermissoesPorUsuarioAsync(int id);
    }
}
