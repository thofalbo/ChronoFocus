namespace Data.Repositories;

public class PermissaoRepository : IPermissaoRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PermissaoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PermissaoDto>> ListarAsync(int id)
    {
        return await _dbContext.Permissoes
            .Include(ac => ac.PermissoesUsuarios)
            .Select(ac => new PermissaoDto
            {
                IdPermissao = ac.Id,
                IdUsuario = id,
                Controlador = ac.Controlador,
                Descricao = ac.Descricao,
                TemPermissao = ac.PermissoesUsuarios.FirstOrDefault(au => au.IdUsuario == id && au.IdPermissao == ac.Id) != null
            })
            .ToListAsync();
    }
}
