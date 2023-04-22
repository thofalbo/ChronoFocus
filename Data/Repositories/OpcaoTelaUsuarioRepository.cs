namespace Data.Repositories;
public class OpcaoTelaUsuarioRepository : IOpcaoTelaUsuarioRepository
{
    private readonly AppDbContext _dbContext;

    public OpcaoTelaUsuarioRepository(AppDbContext dbContext) => _dbContext = dbContext;
    public async Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario)
    {
        await _dbContext.OpcoesTelaUsuario.AddAsync(opcaoTelaUsuario);
        await _dbContext.SaveChangesAsync();
    }
}