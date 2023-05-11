namespace Core.Interfaces.Repositories;
public interface IUsuarioRepository
{
    
    Task<IEnumerable<Usuario>> BuscarUsuariosAsync();
    
    Task<Usuario> BuscarUsuarioAsync(Usuario usuario);
    Task CadastrarAsync(Usuario usuario);
    // Task<Usuario> Get(string login, string senha);
    Task ExcluirAsync(int id);
    // Task<Usuario> VerificaUsuario(string login, string senha);
    Task<Usuario> BuscarUsuarioAsync(string nome);
}