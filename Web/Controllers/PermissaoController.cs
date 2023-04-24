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
        var permissoes = await _permissaoRepository.ListarPorFuncionarioAsync(permissao.Usuario.Nome);
        return View("_tabelaPermissao", permissoes);
    }
    
    [HttpGet("editar")]
        public IActionResult EditarPermissoes()
    {
        var permissoes = _dbContext.Permissoes.Include(p => p.Controlador).Include(p => p.Acao).Include(p => p.Usuario).ToList();
        return View("_cadastrar", permissoes);
    }

    [HttpPost("editar")]
    public async Task<IActionResult> EditarPermissoes(EditarPermissaoDto permitido)
    {
        await _permissaoRepository.EditarPermissoesAsync(permitido.Permitidos);

        return RedirectToAction("Index");
    }
}