namespace Web.Controllers;
[Route("opcao")]
public class OpcaoController : AuthenticatedController
{
    private readonly IOpcaoService _opcaoService;
    private readonly IOpcaoRepository _opcaoRepository;
    private readonly AppDbContext _dbContext;

    public OpcaoController
    (
        IOpcaoService opcaoService,
        IOpcaoRepository opcaoRepository,
        AppDbContext dbContext
    )
    {
        _opcaoService = opcaoService;
        _opcaoRepository = opcaoRepository;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var opcoes = await _opcaoService.ListarAsync();
        return View(opcoes);
    }

    [HttpGet("cadastrar")]
    public IActionResult CadastrarGet() => View("_cadastrar");

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(OpcaoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View("_cadastrar", viewModel);

        await _opcaoService.CadastrarAsync(viewModel.Opcao);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:int}")]
    public async Task<IActionResult> EditarGet(int id)
    {
        var opcao = await _opcaoService.ObterPorIdAsync(id);

        if (opcao == null)
            return NotFound();

        var viewModel = new OpcaoViewModel { Opcao = opcao };

        return View("_editar", viewModel);
    }

    [HttpPost("editar")]
    public async Task<IActionResult> EditarPost(OpcaoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View("_editar", viewModel);

        var opcaoExistente = await _opcaoService.ObterPorIdAsync(viewModel.Opcao.Id);

        if (opcaoExistente == null)
            return NotFound();

        await _opcaoService.AtualizarAsync(viewModel.Opcao);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:int}")]
    public async Task<IActionResult> ExcluirGet(int id)
    {
        var opcao = await _opcaoService.ObterPorIdAsync(id);

        if (opcao == null)
            return NotFound();

        var viewModel = new OpcaoViewModel { Opcao = opcao };

        return View("_excluir", viewModel);
    }

    [HttpPost("excluir")]
    public async Task<IActionResult> ExcluirPost(OpcaoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View("_excluir", viewModel);

        var opcaoExistente = await _opcaoService.ObterPorIdAsync(viewModel.Opcao.Id);

        if (opcaoExistente == null)
            return NotFound();

        await _opcaoRepository.ExcluirAsync(opcaoExistente);

        return RedirectToAction(nameof(Index));
    }
}