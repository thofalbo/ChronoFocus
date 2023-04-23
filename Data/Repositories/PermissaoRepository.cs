namespace Data.Repositories;
public class PermissaoRepository : IPermissaoRepository
{
    private readonly AppDbContext _dbContext;

    public PermissaoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Permissao>> ListarAsync()
    {
        return await _dbContext.Permissoes
            .Include(p => p.Usuario)
            .Include(p => p.Controlador)
            .Include(p => p.Acao)
            .ToListAsync();
    }
    public async Task<IEnumerable<Permissao>> ListarPorFuncionarioAsync(string nome)
    {
        return await _dbContext.Permissoes
            .Include(p => p.Usuario)
            .Include(p => p.Controlador)
            .Include(p => p.Acao)
            .Where(p => p.Usuario.Nome.Contains(nome))
            .ToListAsync();
    }
}