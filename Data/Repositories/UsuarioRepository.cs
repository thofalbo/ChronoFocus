namespace Data.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _dbContext;

    public UsuarioRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Usuario>> ListarAsync() => await _dbContext.Usuarios.ToListAsync();

    public async Task<Usuario> ObterPorIdAsync(int id) => await _dbContext.Usuarios.FindAsync(id);
    public async Task<Usuario> Get(string login, string senha)
    {
        return await _dbContext.Usuarios
            .Where(
                x => x.Login.ToLower() == login.ToLower()
                && x.Senha == senha
            ).FirstOrDefaultAsync();
    }

    public async Task<Usuario> VerificaUsuario(string login, string senha)
    {
        var usuariologado = await _dbContext.Usuarios
            .AsSingleQuery()
                .Include(x => x.PermissoesUsuarios)
                .ThenInclude(p => p.Permissao)
                .Where(
                    x => x.Login.ToLower() == login.ToLower()
                    && x.Senha == senha
                )
                .FirstOrDefaultAsync();

        return usuariologado;
    }

    public async Task CadastrarAsync(Usuario usuario)
    {
        await _dbContext.Usuarios.AddAsync(new Usuario
        {
            Nome = usuario.Nome,
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