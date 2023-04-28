namespace Core.Interfaces.Repositories
{
    public interface IAcaoRepository
    {
        Task<IEnumerable<Acao>> ListarAsync();
    }
}