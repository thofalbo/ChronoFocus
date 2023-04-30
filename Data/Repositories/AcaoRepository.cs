namespace Data.Repositories;

public class AcaoRepository : IAcaoRepository
{
    private readonly AppDbContext _dbContext;
    public AcaoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AcaoDto>> ListarAsync(int id)
    {
        var acoes2 = await _dbContext.Acoes
            .Include(ac => ac.AcaoUsuarios)
            .Select(ac => new AcaoUsuarioDto
            {
                Acao = ac,
                TemPermissao = ac.AcaoUsuarios.FirstOrDefault(au => au.IdUsuario == id && au.IdAcao == ac.Id) != null
            })
            .ToListAsync();

        var acoesDto = await _dbContext.Acoes
            .Include(ac => ac.AcaoUsuarios)
            .Select(ac => new AcaoDto
            {
                Id = ac.Id,
                Controlador = ac.Controlador,
                Rota = ac.Rota,
                Descricao = ac.Descricao,
                UsuarioCadastro = ac.UsuarioCadastro,
                TemPermissao = ac.AcaoUsuarios.FirstOrDefault(au => au.IdUsuario == id && au.IdAcao == ac.Id) != null,
                IdUsuario = id
            })
            .ToListAsync();

        return acoesDto;
    }
}
// var acoesUsuario = await _dbContext.AcaoUsuarios
//      .Include(a => a.Acao)
//      .Include(u => u.Usuario)
//      .Where(u => u.Usuario.Nome == nome)
//      .ToListAsync();