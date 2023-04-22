namespace Core.Interfaces.Services;
public interface IOpcaoTelaUsuarioService
{
    Task<IEnumerable<OpcaoTelaUsuario>> ListarAsync();
    Task<OpcaoTelaUsuarioDto> MostrarOpcaoTelaUsuarioDtoAsync();
    Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario);
    // Task<OpcaoTelaUsuario> ObterPorIdAsync(int id);
    // Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario);
    // Task AtualizarAsync(OpcaoTelaUsuario opcaoTelaUsuario);
}