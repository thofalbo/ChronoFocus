namespace Core.Interfaces.Repositories;
public interface ITelaRepository
{
    Task<IEnumerable<Tela>> ListarAsync();
    Task<Tela> ObterPorIdAsync(int id);
    Task<Tela> ObterPorNomeAsync(string tela);
    Task CadastrarAsync(Tela tela);
    Task AtualizarAsync(Tela tela);
    Task ExcluirAsync(Tela tela);
}