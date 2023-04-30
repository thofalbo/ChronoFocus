namespace Data.Repositories;

public class AcaoRepository : IAcaoRepository
{
    private readonly AppDbContext _dbContext;
    public AcaoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AcaoUsuarioDto>> ListarAsync(int id)
    {
        // var acoesNaoRegistradas = await _dbContext.Acoes
        //     .Where(ac => ac.AcaoUsuarios.Any(au => au.IdUsuario == 1))
        //     .ToListAsync();


        // var acoes = await _dbContext.Acoes
        //     .Include(ac => ac.AcaoUsuarios)
        //     .Where(ac => ac.AcaoUsuarios.Any(au => au.IdUsuario == 1))
        //     .Select(ac => new AcaoUsuarioDto
        //     {
        //         Acao = ac,
        //         TemPermissao = ac.AcaoUsuarios.Any(au => au.IdUsuario == 1)
        //     })
        //     .ToListAsync();

        // var acoes = await _dbContext.Acoes
        //     .Include(ac => ac.AcaoUsuarios)
        //     .Select(ac => new AcaoUsuarioDto
        //     {
        //         Acao = ac,
        //         TemPermissao = ac.AcaoUsuarios.Any(au => au.IdUsuario == 1)
        //     })
        //     .ToListAsync();

        // foreach (var acao in acoes)
        // {
        //     if (!acao.TemPermissao)
        //     {
        //         acao.TemPermissao = await _dbContext.AcaoUsuarios
        //             .AnyAsync(au => au.IdUsuario == 1 && au.IdAcao == acao.Acao.Id);
        //     }
        // }

        // var acoes = await _dbContext.Acoes
        //     .Select(ac => new AcaoUsuarioDto
        //     {
        //         Acao = ac,
        //         TemPermissao = _dbContext.AcaoUsuarios
        //             .FirstOrDefault(au => au.IdUsuario == id && au.IdAcao == ac.Id) != null
        //     })
        //     .ToListAsync();

        var acoes2 = await _dbContext.Acoes
            .Include(ac => ac.AcaoUsuarios)
            .Select(ac => new AcaoUsuarioDto
            {
                Acao = ac,
                TemPermissao = ac.AcaoUsuarios.FirstOrDefault(au => au.IdUsuario == id && au.IdAcao == ac.Id) != null
            })
            .ToListAsync();

        return acoes2;
    }
}

// var acoesUsuario = await _dbContext.AcaoUsuarios
//      .Include(a => a.Acao)
//      .Include(u => u.Usuario)
//      .Where(u => u.Usuario.Nome == nome)
//      .ToListAsync();