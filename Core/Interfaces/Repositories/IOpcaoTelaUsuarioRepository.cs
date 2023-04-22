namespace Core.Interfaces.Repositories;
public interface IOpcaoTelaUsuarioRepository
{
    Task<IEnumerable<OpcaoTelaUsuario>> ListarAsync();
    // Task<OpcaoTelaUsuario> ObterPorIdAsync(int id);
    // Task<OpcaoTelaUsuario> ObterPorNomeAsync(string opcaoTelaUsuario);
    Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario);
    // Task AtualizarAsync(OpcaoTelaUsuario opcaoTelaUsuario);
    // Task ExcluirAsync(OpcaoTelaUsuario opcaoTelaUsuario);
}