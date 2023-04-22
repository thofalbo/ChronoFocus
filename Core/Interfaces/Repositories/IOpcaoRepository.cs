namespace Core.Interfaces.Repositories;
public interface IOpcaoRepository
{
    Task<IEnumerable<Opcao>> ListarAsync();
    Task<Opcao> ObterPorIdAsync(int id);
    Task<Opcao> ObterPorNomeAsync(string opcao);
    Task CadastrarAsync(Opcao opcao);
    Task AtualizarAsync(Opcao opcao);
    Task ExcluirAsync(Opcao opcao);
}