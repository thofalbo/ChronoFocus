namespace Core.Interfaces.Repositories
{
    public interface IAcaoRepository
    {
        Task<IEnumerable<AcaoUsuarioDto>> ListarAsync(int id);
    }
}