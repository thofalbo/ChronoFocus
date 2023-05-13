namespace Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<Usuario>> BuscarUsuariosAsync();

        Task<Usuario> BuscarUsuarioAsync(Usuario usuario);
        Task CadastrarAsync(Usuario usuario);
        Task ExcluirAsync(int id);
        Task<Usuario> BuscarUsuarioAsync(string nome);
    }
}
