namespace Data.Repositories;

public class AcaoRepository : IAcaoRepository
{
    private readonly AppDbContext _dbContext;
    public AcaoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Acao>> ListarAsync()
    {
        return await _dbContext.Acoes
            .Include(a => a.AcaoUsuarios)
            .GroupBy(a => a.Controlador)
            .Select(g => new Acao {
                Controlador = g.Key,
                AcaoUsuarios = g.SelectMany(a => a.AcaoUsuarios)
                            .Distinct()
                            .ToHashSet()
            })
            .ToListAsync();
    }
    // public async Task<Acao> BuscarAsync(int id)
    // {
    //     return await _dbContext.Acoes.FindAsync(id);
    // }
}