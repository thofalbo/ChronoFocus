namespace Data.Repositories;
public class AcaoUsuarioRepository : IAcaoUsuarioRepository
{
    private readonly AppDbContext _dbContext;

    public AcaoUsuarioRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AcaoUsuario>> ListarAsync()
    {
        return await _dbContext.AcaoUsuarios
            .Include(p => p.Usuario)
            .Include(p => p.Acao)
            .ToListAsync();
    }
    public async Task<IEnumerable<AcaoUsuario>> ListarPorFuncionarioAsync(string nome)
    {
        return await _dbContext.AcaoUsuarios
            .Include(p => p.Usuario)
            .Include(p => p.Acao)
            .Where(p => p.Usuario.Nome.Contains(nome))
            .ToListAsync();
    }
    // public async Task EditarPermissoesAsync(IEnumerable<AcaoUsuario> permitidos)
    // {        
    //     foreach (AcaoUsuario permissao in permitidos)
    //     {
    //         _dbContext.AcaoUsuarios.Update(permissao);
    //     }
    //     await _dbContext.SaveChangesAsync();
    // }
    public async Task ExcluirPermissaoAsync(AcaoUsuario permissao)
    {
        _dbContext.AcaoUsuarios.Remove(permissao);
        await _dbContext.SaveChangesAsync();
    }
    public async Task AdicionarPermissaoAsync(AcaoUsuario permissao)
    {
        await _dbContext.AcaoUsuarios.AddAsync(permissao);
        await _dbContext.SaveChangesAsync();
    }
}