namespace Web.Controllers;

[Route("acao")]
public class AcaoController : AuthenticatedController
{
    private readonly AppDbContext _dbContext;
    private readonly IAcaoUsuarioService _acaoUsuarioService;
    private readonly IAcaoRepository _acaoRepository;
    private readonly IAcaoUsuarioRepository _acaousuarioRepository;
    public AcaoController(
        AppDbContext dbContext,
        // IAcaoService acaoService,
        IAcaoUsuarioRepository acaousuarioRepository,
        IAcaoRepository acaoRepository
    )
    {
        _dbContext = dbContext;
        // _acaoService = acaoService;
        _acaoRepository = acaoRepository;
        _acaousuarioRepository = acaousuarioRepository;
    }

    [HttpGet("inicio")]
    public IActionResult Index() => View();

    [HttpGet("cadastrar")]
    public async Task<IActionResult> CadastrarGet()
    {
        var acoes = await _acaoRepository.ListarAsync(1);
        return View("_cadastrar", acoes);
    }

    [HttpPost("cadastrar")]
    public async Task CadastrarPost(PermissoesDto model)
    {
        // await _acaoUsuarioService.EditarPermissoesAsync(model);
        
        foreach (var permitido in model.Permitidos)
        {
            var acaoDto = new PermitidoDto
            {
                IdAcao = permitido.IdAcao,
                IdUsuario = permitido.IdUsuario,
                TemPermissao = permitido.TemPermissao
            };

            var acaoUsuario = new AcaoUsuario
            {
                IdAcao = acaoDto.IdAcao,
                IdUsuario = acaoDto.IdUsuario
            };
            
            if (acaoDto.TemPermissao == false && _acaousuarioRepository.ListarPorFuncionarioAsync("Thomaz").ToString().Contains(acaoUsuario.ToString()))
                await _acaousuarioRepository.ExcluirPermissaoAsync(acaoUsuario);
            else if (acaoDto.TemPermissao == true && !_acaousuarioRepository.ListarPorFuncionarioAsync("Thomaz").ToString().Contains(acaoUsuario.ToString()))
                await _acaousuarioRepository.AdicionarPermissaoAsync(acaoUsuario);
        };
    }

}