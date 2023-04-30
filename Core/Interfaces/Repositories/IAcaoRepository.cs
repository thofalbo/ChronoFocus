namespace Core.Interfaces.Repositories
{
    public interface IAcaoRepository
    {
        Task<IEnumerable<AcaoDto>> ListarAsync(int id);
    }
}