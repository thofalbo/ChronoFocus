namespace Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task CadastrarAsync(Usuario usuario);
        Task<Usuario> Get(string login, string senha);
        Task ExcluirAsync(int id);
    }
}