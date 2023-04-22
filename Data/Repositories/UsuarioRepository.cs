namespace Data.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UsuarioRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Usuario> Get(string login, string senha)
    {
        return await _dbContext.Usuarios
            .Where(
                x => x.Login.ToLower() == login.ToLower()
                && x.Senha == senha
            ).FirstOrDefaultAsync();
    }

    public async Task CadastrarAsync(Usuario usuario)
    {
        await _dbContext.Usuarios.AddAsync(new Usuario
        {
            Login = usuario.Login,
            Email = usuario.Email,
            Senha = usuario.Senha,
            DataCadastro = usuario.DataCadastro.ToUniversalTime()
        });
        await _dbContext.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuario != null)
        {
            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
        }
    }

}