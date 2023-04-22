namespace Core.Interfaces.Repositories;
public interface IUsuarioRepository
{
    
    Task<IEnumerable<Usuario>> ListarAsync();
    
    Task<Usuario> ObterPorIdAsync(int id);
    Task CadastrarAsync(Usuario usuario);
    Task<Usuario> Get(string login, string senha);
    Task ExcluirAsync(int id);
}