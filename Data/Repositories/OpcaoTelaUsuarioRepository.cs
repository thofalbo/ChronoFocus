namespace Data.Repositories;
public class OpcaoTelaUsuarioRepository : IOpcaoTelaUsuarioRepository
{
    private readonly AppDbContext _dbContext;

    public OpcaoTelaUsuarioRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task<IEnumerable<OpcaoTelaUsuario>> ListarAsync() => await _dbContext.OpcoesTelaUsuario.ToListAsync();
    public async Task<IEnumerable<OpcaoTelaUsuario>> ListarAsync()
    {
        return await _dbContext.OpcoesTelaUsuario
            .Include(x => x.Opcao)
            .Include(x => x.Tela)
            .Include(x => x.Usuario)
            .ToListAsync();
    }
    // public async Task<OpcaoTelaUsuario> ObterPorIdAsync(int id) => await _dbContext.OpcoesTelaUsuario.FindAsync(id);
    // public async Task<OpcaoTelaUsuario> ObterPorNomeAsync(string opcaoTelaUsuario) => await _dbContext.OpcoesTelaUsuario.SingleOrDefaultAsync(x => x.Rota == opcaoTelaUsuario);

    public async Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario)
    {
        _dbContext.OpcoesTelaUsuario.Add(opcaoTelaUsuario);
        await _dbContext.SaveChangesAsync();
    }
    // public async Task AtualizarAsync(OpcaoTelaUsuario opcaoTelaUsuario)
    // {
    //     _dbContext.OpcoesTelaUsuario.Update(opcaoTelaUsuario);
    //     await _dbContext.SaveChangesAsync();
    // }

    // public async Task ExcluirAsync(OpcaoTelaUsuario opcaoTelaUsuario)
    // {
    //     _dbContext.OpcoesTelaUsuario.Remove(opcaoTelaUsuario);
    //     await _dbContext.SaveChangesAsync();
    // }
}