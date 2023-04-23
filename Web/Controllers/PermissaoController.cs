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
        public IActionResult EditPermissions()
    {
        var permissions = _dbContext.Permissoes.Include(p => p.Controlador).Include(p => p.Acao).Include(p => p.Usuario).ToList();
        return View("_cadastrar", permissions);
    }

    [HttpPost("editar")]
    public IActionResult EditPermissions(IEnumerable<Permissao> permissions)
    {
        if (ModelState.IsValid)
        {
            foreach (var permission in permissions)
            {
                _dbContext.Permissoes.Update(permission);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("_cadastrar", permissions);
    }
}
