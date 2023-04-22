namespace Core.Interfaces.Services;
public interface IOpcaoService
{
    Task<IEnumerable<Opcao>> ListarAsync();
    Task<Opcao> ObterPorIdAsync(int id);
    Task CadastrarAsync(Opcao opcao);
    Task AtualizarAsync(Opcao opcao);
}