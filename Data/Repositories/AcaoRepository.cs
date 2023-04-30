namespace Data.Repositories;

public class AcaoRepository : IAcaoRepository
{
    private readonly AppDbContext _dbContext;
    public AcaoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PermissaoDto>> ListarAsync(int id)
    {
        var permissaoDto = await _dbContext.Acoes
            .Include(ac => ac.AcaoUsuarios)
            .Select(ac => new PermissaoDto
            {
                IdPermissao = ac.Id,
                IdUsuario = id,
                Controlador = ac.Controlador,
                Descricao = ac.Descricao,
                TemPermissao = ac.AcaoUsuarios.FirstOrDefault(au => au.IdUsuario == id && au.IdPermissao == ac.Id) != null
            })
            .ToListAsync();

        return permissaoDto;
    }
}
