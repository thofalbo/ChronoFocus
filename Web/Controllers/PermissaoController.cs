namespace Web.Controllers;

[Route("permissao")]
public class PermissaoController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IPermissaoRepository _permissaoRepository;

    public PermissaoController(AppDbContext dbContext, IPermissaoRepository permissaoRepository)
    {
        _dbContext = dbContext;
        _permissaoRepository = permissaoRepository;
    }
    public IActionResult Index() => View();

    [HttpGet("buscar")]
    public async Task<IActionResult> BuscarGet()
    {
        var permissoes = await _permissaoRepository.ListarAsync();
        return View("_tabelaPermissao", permissoes);
    }

    [HttpPost("buscar")]
    public async Task<IActionResult> BuscarPost(Permissao permissao)
    {
        var permissoes = await _permissaoRepository.ListarPorFuncionarioAsync(permissao.Funcionario.Nome);
        return View("_tabelaPermissao", permissoes);
    }
}
