namespace Core.Interfaces.Services
{
    public interface ITelaService
    {
        Task<IEnumerable<Tela>> ListarAsync();
        Task<Tela> ObterPorIdAsync(int id);
        Task CadastrarAsync(Tela tela);
        Task AtualizarAsync(Tela tela);
    }
}