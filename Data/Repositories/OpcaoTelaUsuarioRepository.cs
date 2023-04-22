namespace Data.Repositories;
public class OpcaoTelaUsuarioRepository : IOpcaoTelaUsuarioRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OpcaoTelaUsuarioRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
    public async Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario)
    {
        await _dbContext.OpcoesTelaUsuario.AddAsync(opcaoTelaUsuario);
        await _dbContext.SaveChangesAsync();
    }
}